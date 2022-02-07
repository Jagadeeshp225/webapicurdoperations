using finalassignmnet2.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace finalassignmnet2.Controllers
{
    public class loginController : ApiController
    {
        context obj = new context();
        public HttpResponseMessage Get()
        {
            try
            {
                var obj1 = obj.login.ToList();
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                 res.Content = new StringContent(JsonConvert.SerializeObject(obj1));
                 res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                // return Request.CreateResponse(HttpStatusCode.OK, obj1);
                return res;

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        public HttpResponseMessage Post(login Model)
        {
            try
            {
                obj.login.Add(Model);
                obj.SaveChanges();
                HttpResponseMessage r1 = new HttpResponseMessage(HttpStatusCode.Created);
                return r1;
            }
            catch
            {
                HttpResponseMessage r1 = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return r1;
            }
        }
        public HttpResponseMessage Put(login Model)
        {
            obj.Entry(Model).State = System.Data.Entity.EntityState.Modified;
            obj.SaveChanges();
            HttpResponseMessage r1 = new HttpResponseMessage(HttpStatusCode.OK);
            return r1;
        }
        public HttpResponseMessage Delete(string email)
        {

            try
            {
                var u = obj.Detail.Find(email);
                if (u != null)
                {
                    obj.Detail.Remove(u);
                    obj.SaveChanges();
                    HttpResponseMessage r1 = new HttpResponseMessage(HttpStatusCode.OK);
                    return r1;

                }
                else
                {
                    HttpResponseMessage r1 = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return r1;
                }

            }
            catch
            {
                HttpResponseMessage r1 = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return r1;
            }
        }
    }
}


