using System;
using System.Collections.Generic;
using System.Text;
//�������
using System.Data;
//using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using MySql.Data.Types;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.Odbc;

namespace EMS.BaseClass
{
    class BaseInfo
    {
        //[DllImport("shell32")]
        //public static extern long ShellExecute()
        ////(ByVal hWnd As Long, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Long) As Long
        //public static extern long 
        //[DllImport("NETAPI32")]
        //public static extern long NetMessageBufferSend(string Server, byte[] yToName, byte[] yFromName, byte[] yMsg, int lSize);

        DataBase data = new DataBase();

        #region ���--������λ��Ϣ
        /// <summary>
        /// ���������λ
        /// </summary>
        /// <param name="client"></param>
        /// <returns>����������λid</returns>
        public int AddUnits(cUnitsInfo units)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
										
			};
            return (data.RunProc("INSERT INTO tb_units (unitcode, fullname, tax, tel, linkman, address, accounts) VALUES (@unitcode,@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }
        #endregion

        #region �޸�--������λ��Ϣ
        /// <summary>
        /// �޸�������λ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateUnits(cUnitsInfo units)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_units set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts where unitcode=@unitcode", prams));
        }
        #endregion

        #region ɾ��--������λ��Ϣ
        /// <summary>
        /// ɾ��������λ
        /// </summary>
        /// <param name="client"></param>
        /// <returns>����������λid</returns>
        public int DeleteUnits(cUnitsInfo units)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode),
			};
            return (data.RunProc("delete from tb_units where unitcode=@unitcode", prams));
        }
        #endregion

        #region ��ѯ--������λ��Ϣ
        /// <summary>
        /// ����--��λ���--�õ�������λ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByUnitCode(cUnitsInfo units, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  MySqlDbType.VarChar, 5, units.UnitCode+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where unitcode like @unitcode", prams, tbName));
        }
        /// <summary>
        /// ����--��λ����--�õ�������λ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByFullName(cUnitsInfo units, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// �õ�����--������λ��Ϣ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnits(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units ORDER BY unitcode", tbName));
        }
        #endregion


        #region ���--�����Ʒ��Ϣ
        /// <summary>
        /// ��ӿ����Ʒ������Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int AddStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  MySqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  MySqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  MySqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  MySqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("INSERT INTO tb_stock (tradecode, fullname, type, standard, unit, produce) VALUES (@tradecode,@fullname,@type,@standard,@unit,@produce)", prams));
        }
        #endregion

        #region �޸�--�����Ʒ��Ϣ
        /// <summary>
        /// �޸Ŀ����Ʒ��Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  MySqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  MySqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  MySqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  MySqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("update tb_stock set fullname=@fullname,type=@type,standard=@standard,unit=@unit,produce=@produce where tradecode=@tradecode", prams));
        }
        #endregion

        #region ɾ��--�����Ʒ��Ϣ
        /// <summary>
        /// ɾ�������Ʒ��Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int DeleteStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
			};
            return (data.RunProc("delete from tb_stock where tradecode=@tradecode", prams));
        }
        #endregion

        #region ��ѯ--������λ��Ϣ
        /// <summary>
        /// ����--��Ʒ����--�õ������Ʒ��Ϣ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <param name="tbName">ӳ��ԭ������</param>
        /// <returns></returns>
        public DataSet FindStockByProduce(cStockInfo stock, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@produce",  MySqlDbType.VarChar, 5, stock.Produce+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where produce like @produce", prams, tbName));
        }
        /// <summary>
        /// ����--��Ʒ����--�õ������Ʒ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindStockByFullName(cStockInfo stock, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, stock.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// �õ�����--�����Ʒ��Ϣ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllStock(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock", tbName));
        }
        #endregion

        #region ���--��˾ְԱ��Ϣ
        /// <summary>
        /// ���--��˾ְԱ--��Ϣ
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int AddEmployee(cEmployeeInfo employee)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  MySqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  MySqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  MySqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  MySqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("INSERT INTO tb_Employee (employeecode, fullname, sex, dept, tel, memo) VALUES (@employeecode,@fullname,@sex,@dept,@tel,@memo)", prams));
        }
        #endregion

        #region �޸�--��˾ְԱ��Ϣ
        /// <summary>
        /// �޸�--��˾ְԱ--��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateEmployee(cEmployeeInfo employee)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  MySqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  MySqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  MySqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  MySqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("update tb_Employee set fullname=@fullname,sex=@sex,dept=@dept,tel=@tel,memo=@memo where employeecode=@employeecode", prams));
        }
        #endregion

        #region ɾ��--��˾ְԱ��Ϣ
        /// <summary>
        /// ɾ��--��˾ְԱ--��Ϣ
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int DeleteEmployee(cEmployeeInfo employee)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  MySqlDbType.VarChar, 5, employee.EmployeeCode),
			};
            return (data.RunProc("delete from tb_employee where employeecode=@employeecode", prams));
        }
        #endregion

        #region ��ѯ--��˾ְԱ��Ϣ
        /// <summary>
        /// ����--ְԱ���ڲ���--�õ���˾ְԱ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByDept(cEmployeeInfo employee, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@dept",  MySqlDbType.VarChar, 20, employee.Dept+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where dept like @dept", prams, tbName));
        }
        /// <summary>
        /// ����--ְԱ����--�õ���˾ְԱ��Ϣ
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByFullName(cEmployeeInfo employee, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20, employee.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// �õ�����--��˾ְԱ��Ϣ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllEmployee(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Employee ORDER BY employeecode", tbName));
        }
        #endregion


        #region ��Ʒ������---���ݹ���
        /// <summary>
        /// �õ��������۶����б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetSaleList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_orders", tbName));
        }
        /// <summary>
        /// ͨ��ָ�����ֶ��Լ��ֶ�ֵ��ȡ���ض��ֶ����ݣ�����֤��ȫ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetTableDateByFiled(string tbName, string tbFiled, string filedValue, string needFiled)
        {
            string cmd = "select "+ needFiled +" from " + tbName + " where " + tbFiled + "=\'" + filedValue + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }        
        /// <summary>
        /// ͨ��ָ�����ֶ��Լ��ֶ�ֵ��ȡ���������ݣ�����֤��ȫ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetTableDateByFiled(string tbName, string tbFiled, string filedValue)
        {
            string cmd = "select * from " + tbName + " where " + tbFiled + "=\'" + filedValue + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }
        /// <summary>
        /// ͨ��������ȡ������Ϣ������֤��ȫ
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetTableAllDataByName(string tbName)
        {
            string cmd = "select * from " + tbName;
            return (data.RunProcReturn(cmd, tbName));          
        }
        /// <summary>
        /// ͨ�������޸ĵ���״̬������ȫ
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateTableStatu(string tbName, string statu)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 255, tbName),
			};
            string cmd = "update " + tbName + " set statu=\'" + statu + "\'";
            return (data.RunProc(cmd, prams));
        }
        /// <summary>
        /// �õ����۶���������ϸ�б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetSaleDetailList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_orders_detailed", tbName));
        }

        public DataSet GetSaleDetailList(string tbName, string tbSaleCode)
        {
            string cmd = "select * from tb_orders_detailed where orders_id=" +"\'" + tbSaleCode + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }
        /// <summary>
        /// �õ��ɹ�����������ϸ�б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetPurchaseList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_purchase", tbName));
        }
        public DataSet GetPurchaseDetailList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_purchase_detail", tbName));
        }
        public DataSet GetPurchaseDetailList(string tbName, string tbPurchaseCode)
        {
            string cmd = "select * from tb_purchase_detail where purchase_code=" + "\'" + tbPurchaseCode + "\'";
            return (data.RunProcReturn(cmd, tbName));
        }
        /// <summary>
        /// �õ�����tbName������Ϣ������Ҫ�������õ����ĵ��ݱ��Ȼ���Զ����
        /// </summary>
        /// <param name="tbName">���ݱ�����</param>
        /// <returns></returns>
        public DataSet GetAllBill(string tbName_trueName)
        {
            return (data.RunProcReturn("select * from " + tbName_trueName + "", tbName_trueName));
        }
        /// <summary>
        /// ����������������˻���-����---���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableMainWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,billinfo.BillCode),
                						//data.MakeInParam("@units",  MySqlDbType.VarChar, 30, billinfo.Units),
                						//data.MakeInParam("@handle",  MySqlDbType.VarChar, 10, billinfo.Handle),
                						//data.MakeInParam("@summary",  MySqlDbType.VarChar, 100, billinfo.Summary),
                						//data.MakeInParam("@fullpayment",  MySqlDbType.Float, 8, billinfo.FullPayment),
                                        //data.MakeInParam("@payment",  MySqlDbType.Float, 8, billinfo.Payment),
			};
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullpayment,payment) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
        }
        /// <summary>
        /// ��������˻��������۵�-����---���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableMainSellhouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            if (AddTableName_trueName == "tb_orders")
            {
                MySqlParameter[] prams = {
                                        data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,billinfo.BillCode),
                                        data.MakeInParam("@customerid", MySqlDbType.VarChar, 20,billinfo.CustomerCode),
                                        data.MakeInParam("@staffid",    MySqlDbType.VarChar, 20,billinfo.SalesPersonCode),
                                        data.MakeInParam("@customername",    MySqlDbType.VarChar, 20,billinfo.CustomerName),
                                        data.MakeInParam("@customertel",    MySqlDbType.VarChar, 32,billinfo.CustomerTEL),
                                        data.MakeInParam("@customeraddress",    MySqlDbType.VarChar, 32,billinfo.CustomerAddress),
                                        data.MakeInParam("@orderdate", MySqlDbType.DateTime, 8, billinfo.orderDate),
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),
                                        data.MakeInParam("@goodscount", MySqlDbType.Int32, 32, billinfo.Qty),
                                        data.MakeInParam("@fullpayment",  MySqlDbType.Float, 8, billinfo.OrderTotalPayment),
			    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (id, customer_id, saler_id, customer_name, customer_tel, customer_address,order_date,bile_date,goods_count,total_pay) VALUES (@billcode,@customerid,@staffid,@customername,@customertel,@customeraddress,@orderdate,@billdate,@goodscount,@fullpayment)", prams));
            }
            else 
            {
                MySqlParameter[] prams = {
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,billinfo.BillCode),
                                        data.MakeInParam("@orderdate", MySqlDbType.DateTime, 8, billinfo.orderDate),
                                        data.MakeInParam("@customerid", MySqlDbType.VarChar, 20,billinfo.CustomerCode),
                                        data.MakeInParam("@staffid",    MySqlDbType.VarChar, 20,billinfo.SalesPersonCode),
                                        data.MakeInParam("@customername",    MySqlDbType.VarChar, 20,billinfo.CustomerName),
                                        data.MakeInParam("@customeraddress",    MySqlDbType.VarChar, 32,billinfo.CustomerAddress),
                                        data.MakeInParam("@customertel",    MySqlDbType.VarChar, 32,billinfo.CustomerTEL),
                                        data.MakeInParam("@goodscount", MySqlDbType.Int32, 32, billinfo.Qty),
                                        data.MakeInParam("@fullpayment",  MySqlDbType.Float, 8, billinfo.OrderTotalPayment),
			    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullgathering,gathering) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
                        
            }
        }
        /// <summary>
        /// �ɹ�--���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTablePurchase(cPurchaseBill billinfo, string AddTableName_trueName)
        {
                MySqlParameter[] prams = 
                {
                        data.MakeInParam("@number",  MySqlDbType.VarChar, 255,billinfo.BillCode),
                        data.MakeInParam("@supplier_number", MySqlDbType.VarChar, 255,billinfo.SupplierCode),
                        data.MakeInParam("@employee_number",    MySqlDbType.VarChar, 255,billinfo.BuyerCode),
                        data.MakeInParam("@order_date",    MySqlDbType.DateTime, 255,billinfo.orderDate),
                        data.MakeInParam("@recive_date",    MySqlDbType.DateTime, 255,billinfo.DeadLine),
                        data.MakeInParam("@totalpay",    MySqlDbType.Float, 255,billinfo.TotalPayment),
                        data.MakeInParam("@statu",  MySqlDbType.VarChar, 255, billinfo.Status),
			    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (number,supplier_number,employee_number,order_date,recive_date,totalpay,statu) VALUES (@number,@supplier_number,@employee_number,@order_date,@recive_date,@totalpay,@statu)", prams));            
        }

        /// <summary>
        /// �ɹ�--����ϸ�����������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTablePurchaseDetail(cPurchaseBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                {
                        data.MakeInParam("@serial_number",  MySqlDbType.VarChar, 255,billinfo.SerialNumber),
                        data.MakeInParam("@detail_number", MySqlDbType.VarChar, 255,billinfo.PurchaseDetaildCode),
                        data.MakeInParam("@purchase_number",    MySqlDbType.VarChar, 255,billinfo.BillCode),
                        data.MakeInParam("@goods_number",    MySqlDbType.VarChar, 255,billinfo.goodsCode),
                        data.MakeInParam("@goods_qty", MySqlDbType.Float, 32, billinfo.Qty),
                        data.MakeInParam("@goods_price",    MySqlDbType.Float, 32,billinfo.goodsPrice),
                        data.MakeInParam("@goods_uint",    MySqlDbType.VarChar, 255,billinfo.goodsUnit),
			    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (serial_number,detail_number,purchase_number,goods_number,goods_qty,goods_price,goods_uint) VALUES (@serial_number,@detail_number,@purchase_number,@goods_number,@goods_qty,@goods_price,@goods_uint)", prams));
        }
        /// <summary>
        /// ���--���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableEntryStock(cStockBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                {
                        data.MakeInParam("@entry_code",  MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                        data.MakeInParam("@purchase_code", MySqlDbType.VarChar, 255,billinfo.PurchaseCode),
                        data.MakeInParam("@goods_count",    MySqlDbType.Int32, 32,billinfo.GoodsCount),
                        data.MakeInParam("@supplier_code",    MySqlDbType.VarChar, 255,billinfo.SupplierCode),
                        data.MakeInParam("@clerk_code",    MySqlDbType.VarChar, 255,billinfo.StaffCode),
                        data.MakeInParam("@clerk_name",    MySqlDbType.VarChar, 255,billinfo.StaffName),
                        data.MakeInParam("@entry_date",    MySqlDbType.DateTime, 255,billinfo.BillDate),
			    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (entry_code, purchase_code, goods_count, supplier_code,clerk_code, clerk_name, entry_date) VALUES (@entry_code, @purchase_code, @goods_count, @supplier_code,@clerk_code, @clerk_name, @out_date)", prams));
        }
        /// <summary>
        /// ���-����ϸ�����������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableEntryStockDetail(cStockBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                    {
                            data.MakeInParam("@entry_detail_code",  MySqlDbType.VarChar, 255,billinfo.EnOutDetailCode),
                            data.MakeInParam("@entry_code", MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                            data.MakeInParam("@goods_code",    MySqlDbType.VarChar, 255,billinfo.GoodCode),
                            data.MakeInParam("@goods_name",    MySqlDbType.VarChar, 255,billinfo.GoodsName),
                            data.MakeInParam("@goods_uint",    MySqlDbType.VarChar, 255,billinfo.GoodsUint),
                            data.MakeInParam("@goods_price",    MySqlDbType.Float, 32,billinfo.GoodsPrice),
                            data.MakeInParam("@goods_qty", MySqlDbType.Float, 32, billinfo.Qty),
                            data.MakeInParam("@goods_total_price",  MySqlDbType.Float, 32, billinfo.GoodsTotalPrice),
                    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (entry_detail_code, entry_code, goods_code, goods_name, goods_uint, goods_price,goods_qty,goods_total_price) VALUES (@entry_detail_code, @entry_code, @goods_code, @goods_name, @goods_uint, @goods_price,@goods_qty,@goods_total_price)", prams));
        }

        /// <summary>
        /// ����--���������������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableOutStock(cStockBill billinfo, string AddTableName_trueName)
        {
            MySqlParameter[] prams = 
                {
                        data.MakeInParam("@out_code",  MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                        data.MakeInParam("@orders_code", MySqlDbType.VarChar, 255,billinfo.OrdersCode),
                        data.MakeInParam("@goods_count",    MySqlDbType.Int32, 32,billinfo.GoodsCount),
                        data.MakeInParam("@clerk_code",    MySqlDbType.VarChar, 255,billinfo.StaffCode),
                        data.MakeInParam("@clerk_name",    MySqlDbType.VarChar, 255,billinfo.StaffName),
                        data.MakeInParam("@out_date",    MySqlDbType.DateTime, 255,billinfo.BillDate),
			    };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (out_code, orders_code, goods_count, clerk_code, clerk_name, out_date) VALUES (@out_code, @orders_code, @goods_count, @clerk_code, @clerk_name, @out_date)", prams));
        }

        /// <summary>
        /// ����-����ϸ�����������
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableOutStockDetail(cStockBill billinfo, string AddTableName_trueName)
        {
                MySqlParameter[] prams = 
                    {
                            data.MakeInParam("@out_detail_code",  MySqlDbType.VarChar, 255,billinfo.EnOutDetailCode),
                            data.MakeInParam("@out_code", MySqlDbType.VarChar, 255,billinfo.EnOutCode),
                            data.MakeInParam("@goods_code",    MySqlDbType.VarChar, 255,billinfo.GoodCode),
                            data.MakeInParam("@goods_name",    MySqlDbType.VarChar, 255,billinfo.GoodsName),
                            data.MakeInParam("@goods_uint",    MySqlDbType.VarChar, 255,billinfo.GoodsUint),
                            data.MakeInParam("@goods_price",    MySqlDbType.Float, 32,billinfo.GoodsPrice),
                            data.MakeInParam("@goods_qty", MySqlDbType.Float, 32, billinfo.Qty),
                            data.MakeInParam("@goods_total_price",  MySqlDbType.Float, 32, billinfo.GoodsTotalPrice),
                    };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (out_detail_code, out_code, goods_code, goods_name, goods_uint, goods_price,goods_qty,goods_total_price) VALUES (@out_detail_code, @out_code, @goods_code, @goods_name, @goods_uint, @goods_price,@goods_qty,@goods_total_price)", prams));
      }
        /// <summary>
        /// ����ϸ����������ݣ��������������˻��������۵��������˻���
        /// </summary>
        /// <param name="billinfo">���˵������ݽṹ�����</param>
        /// <param name="AddTableName_trueName">���ݿ������ݱ�����</param>
        /// <returns></returns>
        public int AddTableDetailedWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            if ("tb_orders_detailed" == AddTableName_trueName)
            {
                MySqlParameter[] prams = {
                                        data.MakeInParam("@orderdetailcode",MySqlDbType.VarChar, 20,billinfo.orderDetaildCode),
									    data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20, billinfo.BillCode),
                                        data.MakeInParam("@goodscode", MySqlDbType.VarChar, 32, billinfo.goodsCode),
                                        data.MakeInParam("@goodsname",MySqlDbType.VarChar, 32, billinfo.goodsName),
                                        data.MakeInParam("@goodsunit", MySqlDbType.VarChar, 32, billinfo.goodsUnit),
                                        data.MakeInParam("@goodsprice", MySqlDbType.Float, 32, billinfo.goodsPrice),
                                        data.MakeInParam("@goodsqty", MySqlDbType.Float, 32, billinfo.Qty),

            };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (id, orders_id, goods_id, goods_name, goods_uint, goods_price,goods_qty) VALUES (@orderdetailcode,@billcode,@goodscode,@goodsname,@goodsunit,@goodsprice,@goodsqty)", prams));
       
            }
            else
            {
                MySqlParameter[] prams = {
									    data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20, billinfo.BillCode),
                						//data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 20,billinfo.TradeCode),
                						//data.MakeInParam("@fullname",  MySqlDbType.VarChar, 20, billinfo.FullName),
                						//data.MakeInParam("@unit",  MySqlDbType.VarChar, 10, billinfo.TradeUnit),
                						//data.MakeInParam("@qty",  MySqlDbType.Float, 8, billinfo.Qty),
                						//data.MakeInParam("@price",  MySqlDbType.Float, 8, billinfo.Price),
                                        //data.MakeInParam("@tsum",  MySqlDbType.Float, 8, billinfo.TSum),
                                        //data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, billinfo.BillDate),

            };
                return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billcode, tradecode, fullname, unit, qty, price,tsum,billdate) VALUES (@billcode,@tradecode,@fullname,@unit,@qty,@price,@tsum,@billdate)", prams));
                   
            }
            }
        /// <summary>
        /// �޸Ŀ�������ͼ�Ȩƽ���۸�
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateStock_QtyAndAveragerprice(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  MySqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  MySqlDbType.Float, 30,stock.Price),
                						data.MakeInParam("@averageprice",  MySqlDbType.Float, 10, stock.AveragePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,price=@averageprice,averageprice=@averageprice where goods_id=@tradecode", prams));
        }
        /// <summary>
        /// �޸�������Ʒ�ͽ����˻���Ʒ--��Ŀ����Ʒ����
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateSaleStock_Qty(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  MySqlDbType.Float, 30,stock.Qty),
			};
            return (data.RunProc("update tb_stock set qty=@qty where goods_id=@tradecode", prams));
        }
        /// <summary>
        /// �޸Ŀ�����������ۣ��ͽ����˻������һ�μ۸�
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <returns></returns>
        public int UpdateStock_Qty(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  MySqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  MySqlDbType.Float, 30,stock.SalePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,saleprice=@price where goods_id=@tradecode", prams));
        }
        /// <summary>
        /// ������Ʒ���TradeCode,��Ҫ�õ������ͼ�Ȩƽ���۸����ڶ�����¡�
        /// </summary>
        /// <param name="stock">�����Ʒ���ݽṹ�����</param>
        /// <param name="tbName">ӳ�����������</param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(cStockInfo stock, string tbName)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",MySqlDbType.VarChar, 30, stock.TradeCode),
			};
            return (data.RunProcReturn("select * from tb_stock where goods_id like @tradecode", prams, tbName));
        }
        #endregion

        #region ��Ʒ������---��������ϸ��
        /// <summary>
        /// �������---�����˱���ϸ��
        /// </summary>
        /// <param name="currentAccount"></param>
        /// <returns></returns>
#if false
        public int AddCurrentAccount(cCurrentAccount currentAccount)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@billdate",  MySqlDbType.DateTime, 8, currentAccount.BillDate),
                						data.MakeInParam("@billcode",  MySqlDbType.VarChar, 20,currentAccount.BillCode),
                						data.MakeInParam("@addgathering",  MySqlDbType.Float, 8, currentAccount.AddGathering),
                						data.MakeInParam("@factaddfee",  MySqlDbType.Float, 8,currentAccount.FactAddFee),
                						data.MakeInParam("@reducegathering",  MySqlDbType.Float, 8,currentAccount.ReduceGathering),
                						data.MakeInParam("@factfee",  MySqlDbType.Float, 8, currentAccount.FactReduceGathering),
                                        data.MakeInParam("@balance",  MySqlDbType.Float, 8, currentAccount.Balance),
                                        data.MakeInParam("@units",  MySqlDbType.VarChar, 20,currentAccount.Units),
			};
            return (data.RunProc("INSERT INTO tb_currentaccount (billdate, billcode, addgathering, factaddfee, reducegathering, factfee,balance,units) VALUES (@billdate,@billcode,@addgathering,@factaddfee,@reducegathering,@factfee,@balance,@units)", prams));
        }
#endif
        #endregion


        #region ��������--��������
        /// <summary>
        /// ��Ʒ��������--���������˻�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("SELECT a.tradecode, a.fullname, a.averageprice as price, b.qty, b.tsum FROM tb_stock a INNER JOIN (SELECT SUM(qty) AS qty, SUM(tsum) AS tsum, fullname FROM tb_rewarehouse_detailed GROUP BY fullname) b ON a.fullname = b.fullname WHERE (a.price > 0)", tbName));
        }

        /// <summary>
        /// ��Ʒ�������������˻���
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyAllStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("select tradecode,fullname,AVG(price) AS price,sum(qty) as qty,sum(tsum) as tsum from tb_warehouse_detailed group by tradecode,fullname", tbName));
        }
        #endregion

        #region  ��������--����ͳ��
        /// <summary>
        /// ������Ʒ������ϸͳ��
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            MySqlParameter[] prams = {
                						//data.MakeInParam("@units",  MySqlDbType.VarChar, 30, "%"+billinfo.Units+"%"),
                						//data.MakeInParam("@handle",  MySqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������,SUM(b.tsum) AS ������� FROM tb_purchase a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_warehouse_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @handle WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// ������Ʒ����ͳ������
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as ��Ʒ���,fullname as ��Ʒ����,sum(qty) as ��������,sum(tsum)as ������� from tb_warehouse_detailed group by tradecode, fullname", tbName));
        }
        #endregion


        #region  ���۹���--����ͳ��
        /// <summary>
        /// ������Ʒ������ϸͳ��
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            MySqlParameter[] prams = {
                						//data.MakeInParam("@units",  MySqlDbType.VarChar, 30,"%"+ billinfo.Units+"%"),
                						//data.MakeInParam("@handle",  MySqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������,SUM(b.tsum) AS ���۽�� FROM tb_orders a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_orders_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @units WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// ������Ʒ����ͳ������
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as ��Ʒ���,fullname as ��Ʒ����,sum(qty) as ��������,sum(tsum) as ���۽�� from tb_orders_detailed group by tradecode, fullname", tbName));
        }
        #endregion

        #region ���۹���--������״��
        /// <summary>
        /// ͳ����Ʒ����״��
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockStatusSum(string tbName)
        {
            return (data.RunProcReturn("select a.tradecode as ��Ʒ���,a.fullname as ��Ʒ����,a.qty as ��������,a.price AS ���۾���,a.tsum as ���۽��,b.qty2 as '�˻�����',b.tsum2 as '�˻����' from (SELECT tradecode,fullname,avg(price)as price,sum(qty) AS qty, sum(tsum) as tsum from tb_orders_detailed group by tradecode,fullname) a left join (SELECT tradecode,fullname,sum(qty) AS qty2, sum(tsum) as tsum2 from tb_resell_detailed group by tradecode,fullname) b on a.tradecode=b.tradecode ", tbName));
        }

        /// <summary>
        /// ��ϸ�˱�����������Ʒ���ۡ��͡���Ʒ�����˻���
        /// </summary>
        /// <param name="strTradeCode"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockDetailed(string strTradeCode, DateTime starDateTime, DateTime endDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT billdate as ��������, billcode as ���ݱ��, tradecode as ��Ʒ���, fullname as ��Ʒ����, price as ���ۼ۸�, qty as ��������, tsum as ���۽�� FROM " + tbName + " where tradecode = '" + strTradeCode + "' AND billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "'", tbName));
        }
        #endregion

        #region ���۹���--��Ʒ��������
        /// <summary>
        /// �������а���������������λ-�����б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetUnitsList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units", tbName));
        }
        /// <summary>
        /// �������а���������������-�����б�
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetHandleList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_employee", tbName));
        }
        /// <summary>
        /// �����۽������
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetTSumDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������, SUM(b.tsum) AS ���۽�� FROM tb_orders a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_orders_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY ���۽�� DESC", tbName));
        }
        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetQtyDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS ��Ʒ���, b.fullname AS ��Ʒ����, SUM(b.qty) AS ��������, SUM(b.tsum) AS ���۽�� FROM tb_orders a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_orders_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY �������� DESC", tbName));
        }
        #endregion

        #region ���۹���--��Ʒ���۳ɱ���ϸ
        /// <summary>
        /// ���ݵ��ݱ��--�õ�������ϸ��������
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetDetailedkByBillCode(string billCode, string tbName)
        {
            return (data.RunProcReturn("SELECT tradecode,fullname,price,tsum,SUM(qty) AS qty FROM tb_orders_detailed WHERE (billcode = '" + billCode + "')group by tradecode,fullname,price,tsum", tbName));
        }
        /// <summary>
        /// ���ݵ��ݱ��--�õ�������ϸ��������
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock where tradecode ='" + tradeCode + "'", tbName));
        }
        /// <summary>
        /// �������ڣ�����ѯ��������������
        /// </summary>
        /// <param name="starDataTime"></param>
        /// <param name="endDataTime"></param>
        /// <returns></returns>
        public DataSet FindSellStock(DateTime starDataTime, DateTime endDataTime)
        {
            return (data.RunProcReturn("select * from tb_orders where (billdate BETWEEN '" + starDataTime + " ' AND '" + endDataTime + " ')", "tb_orders"));
        }
        #endregion


        #region ������--���״��
        /// <summary>
        /// ���������Ʒ--������������
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet setStockStatus(string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock order by qty", tbName));
        }
        /// <summary>
        /// ������Ʒ��ţ���ÿ����Ʒ��������Ϣ
        /// </summary>
        /// <param name="tradeCode"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockLimitByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock where tradecode='" + tradeCode + "'", tbName));
        }
        /// <summary>
        /// �����Ʒ����������
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateStockLimit(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar,5,stock.TradeCode),
                						data.MakeInParam("@upperlimit",  MySqlDbType.Float, 8, stock.UpperLimit),
                						data.MakeInParam("@lowerlimit",  MySqlDbType.Float, 8, stock.LowerLimit),
            };
            return (data.RunProc("update tb_stock set upperlimit=@upperlimit,lowerlimit=@lowerlimit where tradecode=@tradecode", prams));
        }
        #endregion

        #region �����Ʒ�����ޱ���
        /// <summary>
        /// �����Ʒ���ޱ���
        /// </summary>
        /// <returns></returns>
        public DataSet GetLowerLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as ��Ʒ���, fullname as ��Ʒ����, qty as �������,upperlimit as �������,lowerlimit as ������� from tb_stock WHERE (qty < lowerlimit) and lowerlimit > 0", "tb_stock"));
        }
        /// <summary>
        /// �����Ʒ���ޱ���
        /// </summary>
        /// <returns></returns>
        public DataSet GetUpperLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as ��Ʒ���, fullname as ��Ʒ����, qty as �������,upperlimit as �������,lowerlimit as ������� FROM tb_stock WHERE (upperlimit < qty) and upperlimit>0", "tb_stock"));
        }
        #endregion

        #region ����̵�
        public int CheckStock(cStockInfo stock)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  MySqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@check",  MySqlDbType.Float, 8,stock.Check),
			};
            return (data.RunProc("update tb_stock set stockcheck=@check where tradecode=@tradecode", prams));
        }
        #endregion


        #region ����λ��Ϣ����--ϵͳ����
        /// <summary>
        /// ����λ��Ϣ����
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
#if false
        public int UpdateSysUnits(cUnits units)
        {
            MySqlParameter[] prams = {
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_unit set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts", prams));
        }
        public int InsertSysUnits(cUnits units)
        {
            MySqlParameter[] prams = {
                						data.MakeInParam("@fullname",  MySqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  MySqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  MySqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  MySqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  MySqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  MySqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("insert into tb_unit (fullname,tax,tel,linkman,address,accounts) values (@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }

        /// <summary>
        /// �õ�����λ��Ϣ����
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnit()
        {
            return (data.RunProcReturn("select * from tb_unit", "tb_unit"));
        }
#endif
        #endregion

        #region  ���ݿⱸ����ָ�--ϵͳ����
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="bakUpName"></param>
        public void BackUp(string bakUpName)
        {
            data.RunProc("BACKUP DATABASE db_CMS TO DISK ='" + bakUpName + "'");
        }
        /// <summary>
        /// �ָ����ݿ�
        /// </summary>
        /// <param name="reStoreName"></param>
        public void ReStore(string reStoreName)
        {
            data.RunProc("use master RESTORE DATABASE db_CMS from disk='" + reStoreName + "'");
        }
        #endregion

        #region  ϵͳ��������--ϵͳ����
        /// <summary>
        /// ����ָ�������ݱ�������ݱ�������
        /// </summary>
        /// <param name="tbName_true"></param>
        public void ClearTable(string tbName_true)
        {
            data.RunProc("delete from " + tbName_true + "");
        }
        #endregion

        #region ϵͳ����Ա��Ȩ������--ϵͳ����
        /// <summary>
        /// ���ϵͳ����Ա
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public void AddSysUser(string userName, string pwd)
        {
            data.RunProc("INSERT INTO tb_power (sysuser, password) VALUES ('" + userName + "', '" + pwd + "')");
        }
        /// <summary>
        /// ɾ��ϵͳ����Ա
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSysUser(int ID)
        {
            data.RunProc("delete from tb_power where id='" + ID + "'");
        }
        /// <summary>
        /// �������ϵͳ�û���Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUser()
        {
            return (data.RunProcReturn("select * from tb_power", "tb_Power"));
        }
        /// <summary>
        /// �����û�����---��ѯϵͳ�û�
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool FindUserName(string userName)
        {
            DataSet ds = null;
            ds = data.RunProcReturn("select * from tb_power where sysuser='" + userName + "'", "tb_power");
            if (ds.Tables[0].Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// �޸�ϵͳ�û���Ϣ������Ӧ��Ȩ��
        /// </summary>
        /// <param name="popedom"></param>
        public void UpdateSysUser(cPopedom popedom)
        {
            MySqlParameter[] prams = {
                                        data.MakeInParam("@id",  MySqlDbType.Int32, 4, popedom.ID),
									    data.MakeInParam("@sysuser",  MySqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  MySqlDbType.VarChar, 20,popedom.Password),
                						data.MakeInParam("@stock",  MySqlDbType.Bit, 1, popedom.Stock),
                						data.MakeInParam("@vendition",  MySqlDbType.Bit, 1, popedom.Vendition),
                						data.MakeInParam("@storage",  MySqlDbType.Bit, 1, popedom.Storage),
                						data.MakeInParam("@system",  MySqlDbType.Bit, 1, popedom.SystemSet),
                                        data.MakeInParam("@base",  MySqlDbType.Bit, 1, popedom.Base_Info),
			};
            int i = data.RunProc("update tb_power set sysuser=@sysuser,password=@password,stock=@stock,vendition=@vendition,storage=@storage,system=@system,base=@base where id=@id", prams);
        }
        #endregion

        #region ������λ����
        /// <summary>
        /// ������λ�б�--��ͳ��Ӧ�ն�-���Ӽ�����
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnitsList()
        {
            return (data.RunProcReturn("SELECT units as ������λ, SUM(addgathering) AS Ӧ������, SUM(reducegathering) AS Ӧ�ռ��� FROM tb_currentaccount GROUP BY units", "tb_currentaccount"));
        }
        /// <summary>
        ///��ѯ��ָ�������ڶ���--�Ƿ���ڣ�����ѯ���
        /// </summary>
        /// <param name="units"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet FindCurrentAccountDate(string units, DateTime starDateTime, DateTime endDateTime)
        {
            return (data.RunProcReturn("SELECT * FROM tb_currentaccount WHERE units='" + units + "' AND billdate BETWEEN '" + starDateTime + "'AND '" + endDateTime + "'", "tb_currentaccount"));
        }
        /// <summary>
        /// �������ˣ������ݵ��ݱ��--��ѯ��ϸ��������
        /// </summary>
        /// <param name="billcode"></param>
        /// <param name="tb_Detailed_true"></param>
        /// <returns></returns>
        public DataSet FindDetailde(string tb_Detailed_true, string billcode)
        {
            return (data.RunProcReturn("select * from " + tb_Detailed_true + " where (billcode='" + billcode + "')ORDER BY tsum", "detailed"));
        }
        /// <summary>
        /// �������ˣ������ݵ��ݱ��--��ѯ����������
        /// </summary>
        /// <param name="tb_Main_true"></param>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public DataSet FindMain(string tb_Main_true, string billcode)
        {
            return (data.RunProcReturn("select * from " + tb_Main_true + " where billcode='" + billcode + "'", "main"));
        }
        #endregion

        #region �������߹���
        //ShellExecute Me.hWnd, "open", "http://www.mingrisoft.com", 1, 1, 5
        public void OpenInernet()
        {

        }
        #endregion

        #region ϵͳ��¼
        /// <summary>
        /// ϵͳ��¼
        /// </summary>
        /// <param name="popedom"></param>
        /// <returns></returns>
        public DataSet Login(cPopedom popedom)
        {
            MySqlParameter[] prams = {
									    data.MakeInParam("@sysuser",  MySqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  MySqlDbType.VarChar, 20,popedom.Password),
			};
            return (data.RunProcReturn("SELECT * FROM user WHERE (userName = @sysuser) AND (userPassword = @password)", prams, "user"));
        }

        #endregion
    }
    #region ����������λ--���ݽṹ
    public class cUnitsInfo
    {
        private string unitcode = "";
        private string fullname = "";
        private string tax = "";
        private string tel = "";
        private string linkman = "";
        private string address = "";
        private string accounts = "";
        private float gathering = 0;
        private float payment = 0;
        /// <summary>
        /// ��λ���
        /// </summary>
        public string UnitCode
        {
            get { return unitcode; }
            set { unitcode = value; }
        }
        /// <summary>
        /// ��λȫ��
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ��λ˰��
        /// </summary>
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string LinkMan
        {
            get { return linkman; }
            set { linkman = value; }
        }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// ��λ��ַ
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// �����м��˺�
        /// </summary>
        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        /// <summary>
        /// �ۼ�Ӧ�տ�
        /// </summary>
        public float Gathering
        {
            get { return gathering; }
            set { gathering = value; }
        }
        /// <summary>
        /// �ۼ�Ӧ����
        /// </summary>
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }
    }

    #endregion

    #region ��������Ʒ--���ݽṹ
    public class cStockInfo
    {
        private string tradecode = "";
        private string fullname = "";
        private string tradetpye = "";
        private string standard = "";
        private string tradeunit = "";
        private string produce = "";
        private float qty = 0;
        private float price = 0;
        private float averageprice = 0;
        private float saleprice = 0;
        private float check = 0;
        private float upperlimit = 0;
        private float lowerlimit = 0;
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string TradeCode
        {
            get { return tradecode; }
            set { tradecode = value; }
        }
        /// <summary>
        /// ��λȫ��
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ��Ʒ�ͺ�
        /// </summary>
        public string TradeType
        {
            get { return tradetpye; }
            set { tradetpye = value; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string Standard
        {
            get { return standard; }
            set { standard = value; }
        }
        /// <summary>
        /// ��Ʒ��λ
        /// </summary>
        public string Unit
        {
            get { return tradeunit; }
            set { tradeunit = value; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string Produce
        {
            get { return produce; }
            set { produce = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// ����ʱ���һ�μ۸�
        /// </summary>
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// ��Ȩƽ���۸�
        /// </summary>
        public float AveragePrice
        {
            get { return averageprice; }
            set { averageprice = value; }
        }
        /// <summary>
        /// ����ʱ�����һ������
        /// </summary>
        public float SalePrice
        {
            get { return saleprice; }
            set { saleprice = value; }
        }
        /// <summary>
        /// �̵�����
        /// </summary>
        public float Check
        {
            get { return check; }
            set { check = value; }
        }
        /// <summary>
        /// ��汨������
        /// </summary>
        public float UpperLimit
        {
            get { return upperlimit; }
            set { upperlimit = value; }
        }
        /// <summary>
        /// ��汨������
        /// </summary>
        public float LowerLimit
        {
            get { return lowerlimit; }
            set { lowerlimit = value; }
        }
    }

    #endregion

    #region ���幫˾ְԱ--���ݽṹ
    public class cEmployeeInfo
    {
        private string employeecode = "";
        private string fullname = "";
        private string sex = "";
        private string dept = "";
        private string tel = "";
        private string memo = "";
        /// <summary>
        /// ְԱ���
        /// </summary>
        public string EmployeeCode
        {
            get { return employeecode; }
            set { employeecode = value; }
        }
        /// <summary>
        /// ְԱ����
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// ְԱ�Ա�
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// ���ڲ���
        /// </summary>
        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        /// <summary>
        /// ְԱ�绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// ��ע��Ϣ
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }

    #endregion

    #region �������۶������˵���--���ݽṹ
    public class cBillInfo
    {
        //���۶�����&�ṹ
        private DateTime bill_date = DateTime.Now;   //¼����������
        private DateTime order_date = DateTime.Now;  //�µ�����
        private string bill_code = "";               //���۶������
        private string customer_code = "";           //�ͻ����
        private string customer_name = "";           //�ͻ�����
        private string customer_tel = "";            //�ͻ���ϵ�绰
        private string customer_address = "";        //�ͻ��ջ���ַ
        private string salesPerson_code = "";          //�ӵ�Ա����
        private string sales_person = "";            //�ӵ�Ա����  
        private float orderTotal_payment = 0;        //�����ܽ��
        private string status = "";                 //����״̬
         private int detail_number = 0;                //��ϸ����

        //���۶�����ϸ��ṹ
        private string orderDetaild_code = "";       //������ϸ��ˮ��
        private string order_code = "";              //����������۶����� == billcode
        private string goods_code = "";              //��Ʒ���
        private float qty = 0;                       //��������
        private string goods_name = "";              //��Ʒ����
        private string goods_unit = "";              //��Ʒ��λ
        private float goods_price = 0;             //��Ʒ����

        /// <summary>
        /// ¼����������
        /// </summary>
        public DateTime BillDate
        {
            get { return bill_date; }
            set { bill_date = value; }
        }
        /// <summary>
        /// �µ�����
        /// </summary>
        public DateTime orderDate
        {
            get { return order_date; }
            set { order_date = value; }
        }
        /// <summary>
        /// ���۶������
        /// </summary>
        public string BillCode
        {
            get { return bill_code; }
            set { bill_code = value; }
        }
        /// <summary>
        /// �ͻ����
        /// </summary>
        public string CustomerCode
        {
            get { return customer_code; }
            set { customer_code = value; }
        }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string CustomerName
        {
            get { return customer_name; }
            set { customer_name = value; }
        }
        /// <summary>
        /// �ͻ���ϵ�绰
        /// </summary>
        public string CustomerTEL
        {
            get { return customer_tel; }
            set { customer_tel = value; }
        }
        /// <summary>
        /// �ͻ��ջ���ַ
        /// </summary>
        public string CustomerAddress
        {
            get { return customer_address; }
            set { customer_address = value; }
        }
        /// <summary>
        /// �ӵ�Ա����
        /// </summary>
        public string SalesPersonCode
        {
            get { return salesPerson_code; }
            set { salesPerson_code = value; }
        }
        /// <summary>
        /// �ӵ�Ա����
        /// </summary>
        public string SalesPersonName
        {
            get { return sales_person; }
            set { sales_person = value; }
        }
        /// <summary>
        /// �����ܽ��
        /// </summary>
        public float OrderTotalPayment
        {
            get { return orderTotal_payment; }
            set { orderTotal_payment = value; }
        }

        /// <summary>
        /// ������ϸ��ˮ��
        /// </summary>
        public string orderDetaildCode
        {
            get { return orderDetaild_code; }
            set { orderDetaild_code = value; }
        }
        /// <summary>
        /// ����������۶�����
        /// </summary>
        public string orderCode
        {
            get { return order_code; }
            set { order_code = value; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string goodsCode
        {
            get { return goods_code; }
            set { goods_code = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string goodsName
        {
            get { return goods_name; }
            set { goods_name = value; }
        }
        /// <summary>
        /// ��Ʒ��λ
        /// </summary>
        public string goodsUnit
        {
            get { return goods_unit; }
            set { goods_unit = value; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public float goodsPrice
        {
            get { return goods_price; }
            set { goods_price = value; }
        }
        /// <summary>
        /// ����״̬
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// ��ϸ����
        /// </summary>
        public int DetailNumber
        {
            get { return detail_number; }
            set { detail_number = value; }
        }
    }
    #endregion
    #region ����ɹ��������˵���--���ݽṹ
    public class cPurchaseBill
    {
        //�ɹ�������&�ṹ
        private DateTime bill_date = DateTime.Now;   //¼����������
        private DateTime order_date = DateTime.Now;  //�µ�����
        private DateTime deadline = DateTime.Now;    //Ҫ������
        private string bill_code = "";               //�ɹ��������
        private string supplier_code = "";           //��Ӧ�̱��
        private string supplier_name = "";           //��Ӧ������
        private string supplier_tel = "";            //��Ӧ����ϵ�绰
        private string supplier_address = "";        //��Ӧ�̵�ַ
        private string buyer_code = "";             //�ɹ�Ա����
        private string buyer_name = "";            //�ɹ�Ա����  
        private float Total_payment = 0;            //�����ܽ��
        private string status = "";                 //����״̬
        private int detail_number = 0;                //��ϸ����

        //�ɹ�������ϸ��ṹ
        private string serial_number = ""; //��ϸ���
        private string purchase_detail_code = "";       //������ϸ���
        private string purchase_code = "";              //������Ĳɹ������� == billcode
        private string goods_code = "";              //��Ʒ���
        private float qty = 0;                       //��������
        private string goods_name = "";              //��Ʒ����
        private string goods_unit = "";              //��Ʒ��λ
        private float goods_price = 0;             //��Ʒ����
        private float goods_total_price = 0;        //������ϸС��

        /// <summary>
        /// ¼����������
        /// </summary>
        public DateTime BillDate
        {
            get { return bill_date; }
            set { bill_date = value; }
        }
        /// <summary>
        /// �µ�����
        /// </summary>
        public DateTime orderDate
        {
            get { return order_date; }
            set { order_date = value; }
        }
        /// <summary>
        /// Ҫ������
        /// </summary>
        public DateTime DeadLine
        {
            get { return deadline; }
            set { deadline = value; }
        }

        /// <summary>
        /// ��Ӧ�̵�ַ
        /// </summary>
        public string SupplierAddress
        {
            get { return supplier_address; }
            set { supplier_address = value; }
        }


        /// <summary>
        /// ��Ӧ����ϵ�绰
        /// </summary>
        public string SupplierTel
        {
            get { return supplier_tel; }
            set { supplier_tel = value; }
        }

        /// <summary>
        /// ��Ӧ������
        /// </summary>
        public string SupplierName
        {
            get { return supplier_name; }
            set { supplier_name = value; }
        }
        /// <summary>
        /// ��Ӧ�̱��
        /// </summary>
        public string SupplierCode
        {
            get { return supplier_code; }
            set { supplier_code = value; }
        }


        /// <summary>
        /// �ɹ��������
        /// </summary>
        public string BillCode
        {
            get { return bill_code; }
            set { bill_code = value; }
        }

        /// <summary>
        /// �ɹ�Ա����
        /// </summary>
        public string BuyerCode
        {
            get { return buyer_code; }
            set { buyer_code = value; }
        }
        /// <summary>
        /// �ɹ�Ա����
        /// </summary>
        public string BuyerName
        {
            get { return buyer_name; }
            set { buyer_name = value; }
        }
        /// <summary>
        /// �����ܽ��
        /// </summary>
        public float TotalPayment
        {
            get { return Total_payment; }
            set { Total_payment = value; }
        }

        /// <summary>
        /// ��ϸ��ˮ��
        /// </summary>
        public string SerialNumber
        {
            set { serial_number = value; }
            get { return serial_number; }
        }

        /// <summary>
        /// ������ϸ���
        /// </summary>
        public string PurchaseDetaildCode
        {
            get { return purchase_detail_code; }
            set { purchase_detail_code = value; }
        }
        /// <summary>
        /// ������Ĳɹ�������
        /// </summary>
        public string PurchaseCode
        {
            get { return purchase_code; }
            set { purchase_code = value; }
        }
        /// <summary>
        /// ��Ʒ���
        /// </summary>
        public string goodsCode
        {
            get { return goods_code; }
            set { goods_code = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string goodsName
        {
            get { return goods_name; }
            set { goods_name = value; }
        }
        /// <summary>
        /// ��Ʒ��λ
        /// </summary>
        public string goodsUnit
        {
            get { return goods_unit; }
            set { goods_unit = value; }
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public float goodsPrice
        {
            get { return goods_price; }
            set { goods_price = value; }
        }
        /// <summary>
        /// ��ϸС��
        /// </summary>
        public float GoodsTotalPrice
        {
            get { return goods_total_price; }
            set { goods_total_price = value; }          
        }
        /// <summary>
        /// ����״̬
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// ��ϸ����
        /// </summary>
        public int DetailNumber
        {
            get { return detail_number; }
            set { detail_number = value; }
        }
    }
    #endregion

    #region   �������ⵥ���˵���--���ݽṹ
    public class cStockBill
    {
        private DateTime bill_date = DateTime.Now;   //��������
        private int goods_count = 0;

        //������
        private string entry_code = "";
        private string purchase_code = "";

        private string supplier_code = "";
        
        private string staff_code = "";
        private string staff_name = "";

        private string out_code = "";

        //��ϸ��
        private string entry_detail_code = "";
        private string en_code = "";

        private string o_code = "";
        private string orders_code = "";

        private string goods_code = "";
        private string goods_name = "";
        private string goods_uint = "";
        private float goods_price = 0;
        private int goods_qty = 0;
        private float goods_total_price = 0;
        
        /// <summary>
        /// ��������������
        /// </summary>
        public DateTime BillDate
        {
            get { return bill_date; }
            set { bill_date = value; }
        }
        /// <summary>
        /// ��ϸ������
        /// </summary>
        public int GoodsCount
        {
            get { return goods_count;}
            set { goods_count = value;}
        }
        /// <summary>
        /// ��ⵥ��
        /// </summary>
        public string EntryCode
        {
            get { return entry_code; }
            set { entry_code = value;}
        }
        /// <summary>
        /// �ɹ�����
        /// </summary>
        public string PurchaseCode
        {
            get { return purchase_code;}
            set {purchase_code = value;}
        }
        /// <summary>
        /// ��Ӧ�̺�
        /// </summary>
        public string SupplierCode
        {
            get { return supplier_code;}
            set {supplier_code = value;}
        }
        /// <summary>
        /// Ա����
        /// </summary>
        public string StaffCode
        {
            get { return staff_code;}
            set {staff_code = value;}
        }
        /// <summary>
        /// Ա������
        /// </summary>
        public string StaffName
        {
            get { return staff_name; }
            set { staff_name = value; }
        }
        /// <summary>
        /// ����ⵥ��
        /// </summary>
        public string EnOutCode
        {
            get { return out_code;}
            set {out_code = value;}
        }

        /// <summary>
        /// �������ϸ��ˮ��
        /// </summary>
        public string EnOutDetailCode
        { 
            get {return entry_detail_code;}
            set {entry_detail_code=value;}
        }
        ///// <summary>
        ///// ͬ��ϸ���������ⵥ��
        ///// </summary>
        //public string EnCode
        //{
        //    get { return en_code;}
        //    set {en_code=value;}
        //}
        /// <summary>
        /// ͬ��ϸ������ĳ���ⵥ��
        /// </summary>
        public string EnOtCode
        {
            get { return o_code;}
            set {o_code=value;}
        }
        /// <summary>
        /// ���۵���
        /// </summary>
        public string OrdersCode
        {
            get {return orders_code;}
            set {orders_code=value;}
        }
        /// <summary>
        /// ��Ʒ��
        /// </summary>
        public string GoodCode
        {
            get {return goods_code;}
            set {goods_code=value;}
        }
        /// <summary>
        /// ��Ʒ��
        /// </summary>
        public string GoodsName
        {
            get {return goods_name;}
            set {goods_name=value;}
        }

        /// <summary>
        /// ��Ʒ������λ
        /// </summary>
        public string GoodsUint
        {
            get {return goods_uint;}
            set {goods_uint=value;}
        }
        /// <summary>
        /// ��Ʒ�۸�
        /// </summary>
        public float GoodsPrice
        {
            get {return goods_price;}
            set {goods_price=value;}
        }
        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public int Qty
        {
            get { return goods_qty;}
            set {goods_qty=value;}
        }
        /// <summary>
        /// ��ϸС��
        /// </summary>
        public float GoodsTotalPrice
        {
            get { return goods_total_price;}
            set {goods_total_price=value;}
        }
    }
    #endregion

    #region ���������˱���ϸ--���ݽṹ
    public class cCurrentAccount
        {
            private DateTime billdate = DateTime.Now;
            private string billcode = "";
            private float addgathering = 0;             //Ӧ������
            private float factaddfee = 0;             //ʵ������
            private float reducegathering = 0;        //Ӧ�ռ���
            private float factreducegathering = 0;    //ʵ�ʼ���
            private float balance = 0;  //Ӧ�������� ���
            private string units = "";

            /// <summary>
            /// ¼������
            /// </summary>
            public DateTime BillDate
            {
                get { return billdate; }
                set { billdate = value; }
            }/// <summary>
            /// ���ݱ��
            /// </summary>
            public string BillCode
            {
                get { return billcode; }
                set { billcode = value; }
            }/// <summary>
            /// Ӧ������
            /// </summary>
            public float AddGathering
            {
                get { return addgathering; }
                set { addgathering = value; }
            }/// <summary>
            /// ʵ������
            /// </summary>
            public float FactAddFee
            {
                get { return factaddfee; }
                set { factaddfee = value; }
            }/// <summary>
            /// Ӧ�ռ���
            /// </summary>
            public float ReduceGathering
            {
                get { return reducegathering; }
                set { reducegathering = value; }
            }/// <summary>
            /// ʵ�ʼ���
            /// </summary>
            public float FactReduceGathering
            {
                get { return factreducegathering; }
                set { factreducegathering = value; }
            }/// <summary>
            /// ���(Ӧ�ս��-ʵ�ʽ��)
            /// </summary>
            public float Balance
            {
                get { return balance; }
                set { balance = value; }
            }/// <summary>
            /// ������λ
            /// </summary>
            public string Units
            {
                get { return units; }
                set { units = value; }
            }
        }

        #endregion

        #region ���屾��λ��Ϣ����--���ݽṹ
        public class cUnits
        {
            private string fullname = "";
            private string tax = "";
            private string tel = "";
            private string linkman = "";
            private string address = "";
            private string accounts = "";

            /// <summary>
            /// ��λȫ��
            /// </summary>
            public string FullName
            {
                get { return fullname; }
                set { fullname = value; }
            }
            /// <summary>
            /// ˰��
            /// </summary>
            public string Tax
            {
                get { return tax; }
                set { tax = value; }
            }
            /// <summary>
            /// ��λ�绰
            /// </summary>
            public string Tel
            {
                get { return tel; }
                set { tel = value; }
            }
            /// <summary>
            /// ��ϵ��
            /// </summary>
            public string Linkman
            {
                get { return linkman; }
                set { linkman = value; }
            }
            /// <summary>
            /// ��ϵ��ַ
            /// </summary>
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            /// <summary>
            /// �����м��˺�
            /// </summary>
            public string Accounts
            {
                get { return accounts; }
                set { accounts = value; }
            }
        }

        #endregion

        #region ������������ϸ���������ݽṹ
        public class cCurrentaccount
        {
            private DateTime billdate = DateTime.Now;
            private string billcode = "";
            private float addgathering = 0;
            private float factaddfee = 0;
            private float reducegathering = 0;
            private float factfee = 0;
            private float balance = 0;
            private string units = "";
            /// <summary>
            /// ¼������
            /// </summary>
            public DateTime BillDate
            {
                get { return billdate; }
                set { billdate = value; }
            }
            /// <summary>
            /// ���ݱ��
            /// </summary>
            public string BillCode
            {
                get { return billcode; }
                set { billcode = value; }
            }
            /// <summary>
            /// Ӧ������
            /// </summary>
            public float AddGathering
            {
                get { return addgathering; }
                set { addgathering = value; }
            }
            /// <summary>
            /// ʵ������
            /// </summary>
            public float FactAddfee
            {
                get { return factaddfee; }
                set { factaddfee = value; }
            }
            /// <summary>
            /// Ӧ�ռ���
            /// </summary>
            public float ReduceGathering
            {
                get { return reducegathering; }
                set { reducegathering = value; }
            }
            /// <summary>
            /// ʵ�ʼ���
            /// </summary>
            public float FactFee
            {
                get { return factfee; }
                set { factfee = value; }
            }
            /// <summary>
            /// Ӧ�����
            /// </summary>
            public float Balance
            {
                get { return balance; }
                set { balance = value; }
            }
            /// <summary>
            /// ������λ
            /// </summary>
            public string Units
            {
                get { return units; }
                set { units = value; }
            }
        }
        #endregion

        #region ����Ȩ�ޣ������ݽṹ
        public class cPopedom
        {
            private int id = 0;
            private string sysuser = "";
            private string password = "";
            Boolean stock = false;
            Boolean vendition = false;
            Boolean storage = false;
            Boolean system = false;
            Boolean base_info = false;
            /// <summary>
            /// ID
            /// </summary>
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            /// <summary>
            /// �û�����
            /// </summary>
            public string SysUser
            {
                get { return sysuser; }
                set { sysuser = value; }
            }
            /// <summary>
            /// �û�����
            /// </summary>
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            /// <summary>
            /// ����Ȩ��
            /// </summary>
            public Boolean Stock
            {
                get { return stock; }
                set { stock = value; }
            }
            /// <summary>
            /// ����Ȩ��
            /// </summary>
            public Boolean Vendition
            {
                get { return vendition; }
                set { vendition = value; }
            }
            /// <summary>
            /// ���Ȩ��
            /// </summary>
            public Boolean Storage
            {
                get { return storage; }
                set { storage = value; }
            }
            /// <summary>
            /// ϵͳ����Ȩ��
            /// </summary>
            public Boolean SystemSet
            {
                get { return system; }
                set { system = value; }
            }
            /// <summary>
            /// ������ϢȨ��
            /// </summary>
            public Boolean Base_Info
            {
                get { return base_info; }
                set { base_info = value; }
            }
        }
        #endregion
    }