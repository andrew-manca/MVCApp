﻿
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

    public class HelperFunctions
    {
        public async Task<string> getTokenAsync()
        {
            string tenantId = "{tenantId}";
            string clientId = "{clientId}";
            string grantType = "client_credentials";
            string clientSecret = "{clientSecret}";
            string resource = "https://management.azure.com/";


            string path = "https://login.microsoftonline.com/" + tenantId + "/oauth2/token";

            var request = new HttpRequestMessage(HttpMethod.Post, path);

            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("client_id", clientId));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", grantType));
            keyValues.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            keyValues.Add(new KeyValuePair<string, string>("resource", resource));

            request.Content = new FormUrlEncodedContent(keyValues);

            HttpClient client = new HttpClient();
            var response = await client.SendAsync(request);
            var token = await JsonSerializer.DeserializeAsync<AuthResponseToken>(await response.Content.ReadAsStreamAsync());


            return token.access_token;
        }
    }
    public class AuthResponseToken
    {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string ext_expires_in { get; set; }
        public string expires_on { get; set; }
        public string not_before { get; set; }
        public string resource { get; set; }
        public string access_token { get; set; }

    }
