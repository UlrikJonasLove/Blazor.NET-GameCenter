using System.Threading.Tasks;

namespace gamecenter.Client.Helpers.Interface
{
    interface IDisplayMessage
    {
        ValueTask DisplayErrorMessage(string message);
        ValueTask DisplaySuccessMessage(string message);
    }
}