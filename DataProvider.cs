﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FootbalManager
{
    /// <summary>
    /// Chứa những hàm xử lý database chung cho tất cả
    /// kết nối
    /// executequẻy
    /// </summary>
    public class DataProvider
    {
        //Khai bao cac thanh phan ket noi va xu ly DB
        SqlConnection cnn; //Ket noi DB
        SqlDataAdapter da; //Xu ly cac cau lenh SQL: Select
        SqlCommand cmd; //Thuc thi cau lenh insert,update,delete

        public DataProvider()
        {
            connect();
        }

        private void connect()
        {
            try
            {
                string strCnn = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
                cnn = new SqlConnection(strCnn);
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cnn.Open();
                Console.WriteLine("Connect success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi ket noi:" + ex.Message);
            }
        }

        //Hàm execute 1 câu lệnh select
        public DataTable executeQuery(string strSelect)
        {
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(strSelect, cnn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Execute fail:" + ex.Message);
            }
            return dt;
        }

        //Hàm execute câu lệnh insert,update,delete
        public bool executeNonQuery(string strSQL)
        {
            try
            {
                cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert/Update/Delete error:" + ex.Message);
                return false;
            }
            return true;
        }

        public DataTable GetDataTable(SqlCommand cmd)
        {
            try
            {



                cmd.Connection = cnn;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateTable(SqlCommand cmd)
        {
            try
            {



                cmd.Connection = cnn;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}



