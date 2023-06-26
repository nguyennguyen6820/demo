using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using StudentMVC.Settings;
using System.ComponentModel;
using System.Net.Mime;
using System.Text.Json;
using System.Text;
using StudentMVC.Dtos;
using StudentMVC.Controllers;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace StudentMVC.Services
{
    public class ApiServices
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public ApiServices(AppSetting appSetting,HttpClient httpClient)
        {
            _apiUrl = appSetting.ApiUrl;
            _httpClient = httpClient;
        }
        public async Task<List<Lop>> GetAllLop()
        {
            var url = $"{_apiUrl}/lop";
            var result = await _httpClient.GetAsync(url);
            if(result.IsSuccessStatusCode)
            {
                var lops = await result.Content.ReadFromJsonAsync<List<Lop>>();
                return lops;
            }
            return new List<Lop>();
        }
        public async Task<Lop> AddLop(LopDTO dto)
        {
            var url = $"{_apiUrl}/lop";
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _httpClient.PostAsync(url, content);
            if(result.IsSuccessStatusCode)
            {
                var lop = await result.Content.ReadFromJsonAsync<Lop>();
                return lop;
            }
            return null;
        }
        public async Task<Lop> EditLop(int malop)
        {
            var url = $"{_apiUrl}/lop/{malop}";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var lop = await result.Content.ReadFromJsonAsync<Lop>();
                return lop;
            }
            return null;
        }
        public async Task<Lop> UpdateLop(LopDTO dto)
        {
            var url = $"{_apiUrl}/lop/edit";
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _httpClient.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                var lop = await result.Content.ReadFromJsonAsync<Lop>();
                return lop;
            }
            return null;
        }
        public async Task<int> DeleteLop(int malop)
        {
            var url = $"{_apiUrl}/lop/delete?malop={malop}";
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return malop;

            }
            return -1;
        }


        //Sinhvien
        public async Task<List<SinhVien>> GetAllSinhVien()
        {
            var url = $"{_apiUrl}/sinhvien";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var sinhviens = await result.Content.ReadFromJsonAsync<List<SinhVien>>();
                return sinhviens;
            }
            return new List<SinhVien>();
        }

        
        public async Task<SinhVien> AddSinhVien(SinhVienDTO dto)
        {
            var url = $"{_apiUrl}/sinhvien";
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _httpClient.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                var sinhvien = await result.Content.ReadFromJsonAsync<SinhVien>();
                return sinhvien;
            }
            return null;
        }
        public async Task<List<SinhVien>> LaySinhVienTheoLop(int malop)
        {
            var url = $"{_apiUrl}/sinhvien/LaySinhVienTheoLop/{malop}";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var sinhviens = await result.Content.ReadFromJsonAsync<List<SinhVien>>();
                return sinhviens;
            }
            return new List<SinhVien>();
        }
        public async Task<SinhVien> EditSinhVien(int masv)
        {
            var url = $"{_apiUrl}/sinhvien/{masv}";
            var result = await _httpClient.GetAsync(url);
            if(result.IsSuccessStatusCode)
            {
                var sinhvien = await result.Content.ReadFromJsonAsync<SinhVien>();
                return sinhvien;

            }
            return null;
        }
        public async Task<SinhVien> UpdateSinhVien(SinhVienDTO dto)
        {
            var url = $"{_apiUrl}/sinhvien/edit";
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _httpClient.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                var sinhvien = await result.Content.ReadFromJsonAsync<SinhVien>();
                return sinhvien;
            }
            return null;
        }
        public async Task<int> DeleteSinhVien(int masv)
        {
            var url = $"{_apiUrl}/sinhvien/delete?masv={masv}";
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return masv;

            }
            return -1;
        }


    }
}
