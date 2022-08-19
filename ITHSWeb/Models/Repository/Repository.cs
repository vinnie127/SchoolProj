﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ITHSWeb.Models;
using ITHSWeb.Models.ViewModel;
using ITHSWeb.Repository.IRepository;
using System.Text;

namespace ITHSWeb.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly IHttpClientFactory _clientFactory;

        public Repository(IHttpClientFactory clientFactory)
        {


            _clientFactory = clientFactory;

        }


        public async Task<bool> CreateAsync(string url, T objToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (objToCreate!= null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");


            }

            else
            {
                return false;
            }


            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);


            if (response.StatusCode==System.Net.HttpStatusCode.Created)
            {

                return true;
            }

            else
            {
                return false;
            }



        }

        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url+Id);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode==System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;

        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               var jsonString = await response.Content.ReadAsStringAsync();
               
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            
            }

            return null;
        }



        public async Task<T> GetAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url+Id);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
               
                return JsonConvert.DeserializeObject<T>(jsonString);
            }

            return null;
        }




        public async Task<IEnumerable<ListStudentVM>> GetStudents(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url+id);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<ListStudentVM>>(jsonString);

            }

            return null;
        }

        public async Task<IEnumerable<CourseListVM>> GetCoursesFromStudent(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<CourseListVM>>(jsonString);

            }

            return null;
        }


        public async Task<IEnumerable<CoursesInTeacherVM>> CoursesInTeacher(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<CoursesInTeacherVM>>(jsonString);

            }

            return null;
        }




        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);

            if (objToUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");


            }

            else
            {
                return false;
            }


            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);


            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {

                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
