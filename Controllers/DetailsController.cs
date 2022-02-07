using finalassignmnet2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;


namespace finalassignmnet2.Controllers
{
    public class DetailsController : ApiController
    {
        context obj = new context();
        [System.Web.Http.HttpGet]
        public HttpResponseMessage details()
        {
            try
            {
                var obj1 = obj.Detail.ToList();
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                res.Content = new StringContent(JsonConvert.SerializeObject(obj1));
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return res;
            }
            catch
            {
                
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                
            }

        }
        public HttpResponseMessage Post(Details Model)
        {
            try
            {
                obj.Detail.Add(Model);
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
[HttpGet]
        public HttpResponseMessage Get(string email)
            {
                Details objuser = obj.Detail.Find(email);
                if (objuser == null)
                {
                    string message = string.Format("User with given email does not exists");
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
                return Request.CreateResponse(HttpStatusCode.OK, objuser);
            }










        
        public HttpResponseMessage Put(Details Model)
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