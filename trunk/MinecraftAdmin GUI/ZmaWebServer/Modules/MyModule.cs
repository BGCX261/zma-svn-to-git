using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpServer.HttpModules;
using HttpServer;
using HttpServer.Sessions;
using System.IO;
using MinecraftWrapper.AddonInterface;
using ZmaSamplePlugin;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper;
using Zicore.MinecraftAdmin;


namespace ZmaWebServer.Modules
{
    class MyModule : HttpModule
    {
        public MyModule(Plugin plugin)
        {
            this.plugin = plugin;
        }

        Plugin plugin;

        /// <summary>
        /// Loads a file from the web folder
        /// </summary>
        /// <param name="fileName">the file relative to the web folder</param>
        /// <returns>the file as string</returns>
        private string LoadFile(String fileName)
        {
            String dir = Path.Combine(Path.GetDirectoryName(plugin.StartUpPath), "Web", fileName);
            String file = string.Empty;
            using (StreamReader sr = new StreamReader(dir))
            {
                FileInfo fi = new FileInfo(fileName);
                file = sr.ReadToEnd();
                sr.Close();
            }
            return file;
        }

        // contains session ids and a bool which indicates if we are logged in
        Dictionary<String, bool> webLogin = new Dictionary<string, bool>();

        /// <summary>
        /// Method that process the URL
        /// </summary>
        /// <param name="request">Information sent by the browser about the request</param>
        /// <param name="response">Information that is being sent back to the client.</param>
        /// <param name="session">Session used to </param>
        /// <returns>true if this module handled the request.</returns>
        public override bool Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
        {
            Authenticate(request, session);

            if (IsAuthenticated(session))
            {
                SendCommand(request, session);
                StreamWriter writer = new StreamWriter(response.Body);
                writer.Write(LoadFile("management.html"));
                writer.Flush();
            }
            else
            {
                StreamWriter writer = new StreamWriter(response.Body);
                writer.Write(LoadFile("index.html"));
                writer.Flush();
            }

            // return true to tell webserver that we've handled the url
            return true;
        }

        /// <summary>
        /// Checks authentication with ZMA
        /// </summary>
        /// <param name="request"></param>
        /// <param name="session"></param>
        private void Authenticate(IHttpRequest request, IHttpSession session)
        {
            if (request.Param["login"].Value != null)
            {
                if (!webLogin.ContainsKey(session.Id))
                    webLogin.Add(session.Id, false);

                String username = request.Param["username"].Value;
                String password = request.Param["password"].Value;
                var userlist = UserCollectionSingletone.GetInstance();
                var user = userlist.GetUserByLogin(username);
                // First check if we have access and the if we can login :-)
                // I use SHA256 with salt so avoid using other authentications
                if (!user.Generated && user.HasWebAccess && HashProvider.GetHash(password, HashProvider.SHA256) == user.PasswordHash)
                {
                    webLogin[session.Id] = true;
                }
            }
        }

        /// <summary>
        /// Sends a chat message to the server
        /// </summary>
        /// <param name="request">web request</param>
        /// <param name="session">web session</param>
        private void SendCommand(IHttpRequest request, IHttpSession session)
        {
            if (request.Param["command"].Value != null)
            {
                string cmd = request.Param["command"].Value;
                plugin.Server.SendServerMessage("Web: " + cmd);
            }
        }

        /// <summary>
        /// check if we are authenticated yet
        /// </summary>
        /// <param name="session">the session with the session id</param>
        /// <returns>IsAuthenticated</returns>
        private bool IsAuthenticated(IHttpSession session)
        {
            return webLogin.ContainsKey(session.Id) && webLogin[session.Id];
        }
    }
}
