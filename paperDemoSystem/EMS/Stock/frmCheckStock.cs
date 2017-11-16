using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.Stock
{
    public partial class frmCheckStock : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        string G_Str_tradecode = "";
        

        public frmCheckStock()
        {
            InitializeComponent();
        }
        //����DataGridView����
        private void SetdgvStockListHeadText()
        {
            dgvStockList.Columns[0].HeaderText = "��Ʒ���";
            dgvStockList.Columns[1].HeaderText = "��Ʒ����";
            dgvStockList.Columns[2].HeaderText = "��Ʒ�ͺ�";
            dgvStockList.Columns[3].HeaderText = "��Ʒ���";
            dgvStockList.Columns[4].HeaderText = "��Ʒ��λ";
            dgvStockList.Columns[5].HeaderText = "��Ʒ����";
            dgvStockList.Columns[6].HeaderText = "�������";
            dgvStockList.Columns[7].Visible = false;
            dgvStockList.Columns[8].Visible = false;
            dgvStockList.Columns[9].Visible = false;
            dgvStockList.Columns[10].HeaderText = "�̵�����";
            dgvStockList.Columns[11].Visible = false;
            dgvStockList.Columns[12].Visible = false;
        }
        private void tlBtnFind_Click(object sender, EventArgs e)
        {
            if (tlCmbStockType.Text == string.Empty)
            {
                MessageBox.Show("��ѯ�����Ϊ�գ�", "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tlCmbStockType.Focus();
                return;
            }
            else
            {
                if (tlTxtFindStock.Text.Trim() == string.Empty)
                {
                    dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
                    this.SetdgvStockListHeadText();
                    return;
                }
            }
            DataSet ds = null;   //����DataSet����
            if (tlCmbStockType.Text == "��Ʒ����")  //����λ��Ų�ѯ
            {
                stockinfo.Produce = tlTxtFindStock.Text;
                ds = baseinfo.FindStockByProduce(stockinfo, "tb_Stock");
                dgvStockList.DataSource = ds.Tables[0].DefaultView;
            }
            else����������������������������������//����λ���Ʋ�ѯ
            {
                stockinfo.FullName = tlTxtFindStock.Text;
                ds = baseinfo.FindStockByFullName(stockinfo, "tb_stock");
                dgvStockList.DataSource = ds.Tables[0].DefaultView;
            }
            this.SetdgvStockListHeadText();
        }

        private void frmCheckStock_Load(object sender, EventArgs e)
        {
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void dgvStockList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tltxtFullName.Text = dgvStockList[1, e.RowIndex].Value.ToString();
            G_Str_tradecode = dgvStockList[0, e.RowIndex].Value.ToString();
        }

        private void tlbtnCheckStock_Click(object sender, EventArgs e)
        {
            if (tltxtCheckStock.Text == string.Empty)
            {
                MessageBox.Show("�̵���������Ϊ�գ�","������ʾ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            //��֤������ı�����Ϊ���������֡�
            for (int i = 0; i < tltxtCheckStock.Text.Length; i++)
            {
                if (!Char.IsNumber(tltxtCheckStock.Text, i))
                {
                    MessageBox.Show("����������ñ���Ϊ���������֣�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            stockinfo.TradeCode = G_Str_tradecode;
            stockinfo.Check = Convert.ToSingle(tltxtCheckStock.Text);
            int d= baseinfo.CheckStock(stockinfo);
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
            MessageBox.Show("��������Ʒ�̵�ɹ���","�ɹ���ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dgvStockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}