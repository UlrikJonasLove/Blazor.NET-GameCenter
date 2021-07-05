using System;
using System.Linq;
using System.Threading.Tasks;
using gamecenter.Shared.DTOs;

namespace gamecenter.Client.Helpers.Interface
{
    public static class IHttpServiceExtensionMethods
    {    
        public static async Task<T> GetHelper<T>(this IHttpService httpService, string url)
        {
            var response = await httpService.Get<T>(url);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public static async Task<PageResponse<T>> GetHelper<T>(this IHttpService httpService, string url, PageDTO pageDto)
        {
            string newUrl = "";
            if(url.Contains("?"))
            {
                newUrl = $"{url}&page={pageDto.Page}&itemsPerPage={pageDto.ItemsPerPage}";
            }
            else 
            {
                newUrl = $"{url}?page={pageDto.Page}&itemsPerPage={pageDto.ItemsPerPage}";
            }
            var response = await httpService.Get<T>(newUrl);
            var amountOfPages = int.Parse(response.HttpResponseMessage.Headers.GetValues("amountOfPages").FirstOrDefault());
            var pageResponse = new PageResponse<T>
            {
                Response = response.Response,
                AmountOfPages = amountOfPages,
            };
            return pageResponse;
        }
    }
    
}
 

