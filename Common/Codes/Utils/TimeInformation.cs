using System;
using System.Net;

namespace EternalResolve.Common.Codes.Utils
{
    public class TimeInformation
    {
        public static DateTime Now;
        public static string GetNetDateTime( )
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create( "https://www.baidu.com" );
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = request.GetResponse( );
                headerCollection = response.Headers;
                foreach ( var h in headerCollection.AllKeys )
                {
                    if ( h == "Date" )
                    {
                        datetime = headerCollection[ h ];
                    }
                }
                return datetime;
            }
            catch ( Exception )
            {
                throw new Exception( "请检查你的网络, 并且再次加载Mod. ( Check your WLAN please , and reload this Mod. )" );
            }
            finally
            {
                if ( request != null )
                {
                    request.Abort( );
                }
                if ( response != null )
                {
                    response.Close( );
                }
                if ( headerCollection != null )
                {
                    headerCollection.Clear( );
                }
            }
        }
    }
}