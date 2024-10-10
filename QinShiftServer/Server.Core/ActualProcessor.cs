using ServerTwo.Core;
using ServerTwo.Interface;

using System.Text;

internal class ActualProcessor
{
    private List<IPipelineProcessor> _processors = new ()
    {
        new EchoPipelineProcessor(),
    };

    public void AddProcessor(IPipelineProcessor processor)
    {
        _processors.Insert(_processors.Count-1, processor);
    }

    internal Response Process(Request request)
    {
        try
        {
            if (_processors.Count == 0)
            {
                throw new QinshiftServerException("No processors found");
            }
            foreach (var processor in _processors)
            {
                if (processor.CanProcess(request))
                {
                    return processor.Process(request);
                }
            }
            throw new QinshiftServerException("No processor found for the request");
        }
        catch (QinshiftServerException ex)
        {
            // Log the exception, but not too much worry, as it is QinshiftServerException
            Console.WriteLine($"QinshiftServerException encountered: {ex.Message}");
            return new Response
            {
                StatusCode = StatusCode.InternalServerError,
                Body = "Something went wrong"
            };
        }
        catch (Exception ex)
        {
            // Log the exception, as it is not QinshiftServerException
            Console.WriteLine($"Other exception encountered ({ex.GetType().FullName}): {ex.Message}");
            return new Response
            {
                StatusCode = StatusCode.InternalServerError,
                Body = "Something went really wrong"
            };
        }
    }
}