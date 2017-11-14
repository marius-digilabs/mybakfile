using System;
using System.Collections.Generic;
using System.Text;
//�������
//using System.Data.SqlClient;
using System.Data;
//���� mysql
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;
//��Դ��������win.51aspx.com(������s���������)

namespace EMS.BaseClass
{
    class DataBase:IDisposable
    {
        //private SqlConnection con;  //sql2008 �������Ӷ���
        private MySqlConnection conn; //MySql 5.7
        string myConnectionString = "Database=PaperDataBase;DataSource=127.0.0.1;UserId=root;Password=root;port=3306;pooling=false;charset=utf8";
        #region   �����ݿ�����
        /// <summary>
        /// �����ݿ�����.
        /// </summary>
        private void Open()
        {
            // �����ݿ�����
            if (conn == null)
            {
                //con = new SqlConnection("Data Source=(local);DataBase=db_CMS;User ID=sa;PWD=sa");
                conn = new MySqlConnection(myConnectionString);
            }
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();

        }
        #endregion

        #region  �ر�����
        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        public void Close()
        {
            if (conn != null)
                conn.Close();
        }
        #endregion

        #region �ͷ����ݿ�������Դ
        /// <summary>
        /// �ͷ���Դ
        /// </summary>
        public void Dispose()
        {
            // ȷ�������Ƿ��Ѿ��ر�
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }
        }
        //��Դ��������win.51aspx.com(�������p��������)

        #endregion

        #region   �����������ת��ΪMySqlParameter����
        /// <summary>
        /// ת������
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param></param>
        /// <param name="Size">������С</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public MySqlParameter MakeInParam(string ParamName, MySqlDbType DbType, int Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        /// <summary>
        /// ��ʼ������ֵ
        /// </summary>
        /// <param name="ParamName">�洢�������ƻ������ı�</param>
        /// <param name="DbType">��������</param>
        /// <param name="Size">������С</param>
        /// <param name="Direction">��������</param>
        /// <param name="Value">����ֵ</param>
        /// <returns>�µ� parameter ����</returns>
        public MySqlParameter MakeParam(string ParamName, MySqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            MySqlParameter param;

            if (Size > 0)
                param = new MySqlParameter(ParamName, DbType, Size);
            else
                param = new MySqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;
            return param;
        }
        #endregion

        #region   ִ�в��������ı�(�����ݿ������ݷ���)
        /// <summary>
        /// ִ������
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        public int RunProc(string procName, MySqlParameter[] prams)
        {
            MySqlCommand cmd = CreateCommand(procName, prams);
            cmd.ExecuteNonQuery();
            this.Close();
            //�õ�ִ�гɹ�����ֵ
            return (int)cmd.Parameters["ReturnValue"].Value;
        }
        /// <summary>
        /// ֱ��ִ��SQL���
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <returns></returns>
        public int RunProc(string procName)
        {
            this.Open();
            //SqlCommand cmd = new SqlCommand(procName, con);
            MySqlCommand cmd = new MySqlCommand(procName, conn);
            cmd.ExecuteNonQuery();
            this.Close();
            return 1;
        }

        #endregion

        #region   ִ�в��������ı�(�з���ֵ)
        /// <summary>
        /// ִ�в�ѯ�����ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet RunProcReturn(string procName, MySqlParameter[] prams,string tbName)
        {
            MySqlDataAdapter dap=CreateDataAdaper(procName, prams);
            DataSet ds = new DataSet();
            dap.Fill(ds,tbName);
            this.Close();
            //�õ�ִ�гɹ�����ֵ
            return ds;
        }

        /// <summary>
        /// ִ�������ı������ҷ���DataSet���ݼ�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcReturn(string procName, string tbName)
        {
            MySqlDataAdapter dap = CreateDataAdaper(procName, null);
            DataSet ds = new DataSet();
            dap.Fill(ds, tbName);
            this.Close();
            //�õ�ִ�гɹ�����ֵ
            return ds;
        }

        #endregion

        #region �������ı���ӵ�MySqlDataAdapter
        /// <summary>
        /// ����һ��SqlDataAdapter�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams">��������</param>
        /// <returns></returns>
        private MySqlDataAdapter CreateDataAdaper(string procName, MySqlParameter[] prams /*SqlParameter[] prams*/)
        {
            this.Open();
            //SqlDataAdapter dap = new SqlDataAdapter(procName,con);
            MySqlDataAdapter dap = new MySqlDataAdapter(procName, conn);
            dap.SelectCommand.CommandType = CommandType.Text;  //ִ�����ͣ������ı�
            if (prams != null)
            {
                foreach (MySqlParameter parameter in prams)
                    dap.SelectCommand.Parameters.Add(parameter);
            }
            //���뷵�ز���
           /* 
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));
            */
            dap.SelectCommand.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));

            return dap;
        }
        #endregion

        #region   �������ı���ӵ�MySqlCommand
        /// <summary>
        /// ����һ��SqlCommand�����Դ���ִ�������ı�
        /// </summary>
        /// <param name="procName">�����ı�</param>
        /// <param name="prams"�����ı��������</param>
        /// <returns>����SqlCommand����</returns>
        private MySqlCommand CreateCommand(string procName, MySqlParameter[] prams)
        {
            // ȷ�ϴ�����
            this.Open();
            MySqlCommand cmd = new MySqlCommand(procName, conn);
            cmd.CommandType = CommandType.Text;�������� //ִ�����ͣ������ı�

            // ���ΰѲ������������ı�
            if (prams != null)
            {
                foreach (MySqlParameter parameter in prams)
                    cmd.Parameters.Add(parameter);
            }
            // ���뷵�ز���
            /*
            cmd.Parameters.Add(
                new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 0, 0,
                string.Empty, DataRowVersion.Default, null));
            */


            //cmd.Parameters.Add(
            //    new MySqlParameter("ReturnValue", MySqlDbType.Int32, 4,
            //    ParameterDirection.ReturnValue, false, 0, 0,
            //    string.Empty, DataRowVersion.Default, 111));

            cmd.Parameters.Add(new MySqlParameter("ReturnValue", MySqlDbType.Int64, 32,
                                ParameterDirection.ReturnValue, false, 0, 0,
                                string.Empty, DataRowVersion.Default, 1111));

            return cmd;
        }
        #endregion
    }
}
