﻿using Microsoft.Data.SqlClient;

namespace ChessLibrary
{
    public class DataLayer
    {
        //public delegate void PassUserInfoDelegate(string username, int chessRating, Bitmap profilePic);
        //public event PassUserInfoDelegate PassUserInfo;

        private string connString;
        public DataLayer()
        {
            connString = "server=tcp:russ-server.database.windows.net,1433;database=ChessDB;user id=russ;password=P@ssword!;encrypt=false;";
            //connString = ConfigurationManager.ConnectionStrings["remoteconnection"].ConnectionString;
        }
        #region Image conversions
        private byte[] ConvertToByteArray(Bitmap bitmap)
        {
            byte[] imageBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //convert the image to the bytes
                imageBytes = ms.ToArray();
            }

            return imageBytes;
        }
        private Bitmap ConvertToBitmap(byte[] img)
        {
            Bitmap ret = null;

            using (MemoryStream ms = new MemoryStream(img))
            {
                ret = new Bitmap(ms);
            }

            return ret;
        }
        #endregion
        #region Get user info
        public Tuple<string, int, Bitmap?> GetUserInfo(string username)
        {
            int chessRating = 0;
            Bitmap? profilePic = null;
            byte[] profilePicAsByteArray;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string qry = @"SELECT * FROM Users WHERE [username] = @username";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // apply chess rating
                    chessRating = (int)reader[2];
                    MessageBox.Show(reader[3].ToString());

                    // get image as byte array user has a stored image
                    if (reader[3].GetType() != typeof(System.DBNull))
                    {
                        profilePicAsByteArray = (byte[])reader[3];
                        profilePic = ConvertToBitmap(profilePicAsByteArray);
                    }
                }

                return new Tuple<string, int, Bitmap?>(
                username,
                chessRating,
                profilePic);
            }
        }
        #endregion
        #region Change user info
        public bool ChangeProfilePic(string username)
        {
            return false;
        }
        public bool ChangeUsername(string username)
        {
            return false;
        }
        #endregion
        #region Register/login user method
        public bool RegisterUser(string username, string password)
        {
            string qry = @"INSERT INTO Users VALUES (" +
                         @"@username, @password, '800', null, GETDATE())";

            // add parameters
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@username", username);
            parameters[1] = new SqlParameter("@password", password);

            return this.ExecuteNonQuery(qry, parameters);
        }
        public bool LoginUser(string username, string password)
        {
            try
            {
                string qry = @"SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";

                // add parameters
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@username", username);
                parameters[1] = new SqlParameter("@password", password);

                int count = (int)this.ExecuteScalar(qry, parameters);
                return count == 1;
            }
            catch { return false; }
        }
        #endregion
        #region Private methods (ExecuteNonQuery & ExecuteScalar)
        private bool ExecuteNonQuery(string qry, SqlParameter[]? parameters)
        {
            bool ret = true;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);

                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            catch { ret = false; }
            finally { conn.Close(); }

            return ret;
        }
        private object ExecuteScalar(string qry, SqlParameter[]? parameters)
        {

            object? ret = null;
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(qry, conn);

                if (parameters != null)
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);

                ret = cmd.ExecuteScalar();
            }
            catch { return null; }
            finally { conn.Close(); }

            return ret;
        }
        #endregion
    }
}
