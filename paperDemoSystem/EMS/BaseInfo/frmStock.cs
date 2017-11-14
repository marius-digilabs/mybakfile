using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS.BaseInfo
{
    public partial class frmStock : Form
    {
        BaseClass.BaseInfo baseinfo = new EMS.BaseClass.BaseInfo();
        BaseClass.cStockInfo stockinfo = new EMS.BaseClass.cStockInfo();
        int G_Int_addOrUpdate = 0;
        public frmStock()
        {
            InitializeComponent();
        }

        private void tlBtnAdd_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            this.clearText();
            G_Int_addOrUpdate = 0;   //���ڣ�Ϊ�������
            //�����Զ����
            DataSet ds = null;
            string P_Str_newTradeCode = "";
            int P_Int_newTradeCode = 0;
            ds = baseinfo.GetAllStock("tb_stock");
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtTradeCode.Text = "T1001";
            }
            else
            {
                P_Str_newTradeCode = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["tradecode"]);
                P_Int_newTradeCode = Convert.ToInt32(P_Str_newTradeCode.Substring(1, 4)) + 1;
                P_Str_newTradeCode = "T" + P_Int_newTradeCode.ToString();
                txtTradeCode.Text = P_Str_newTradeCode;
            }
        }

        private void editEnabled()  //������˹����޹صİ�ť
        {
            groupBox1.Enabled = true;     //����������ʹ�ã�׼������µ�������λ��Ϣ
            tlBtnAdd.Enabled = false;
            tlBtnEdit.Enabled = false;
            tlBtnDelete.Enabled = false;
            tlBtnSave.Enabled = true;
            tlBtnCancel.Enabled = true;
        }
        private void cancelEnabled()
        {
            groupBox1.Enabled = false;
            tlBtnAdd.Enabled = true;
            tlBtnEdit.Enabled = true;
            tlBtnDelete.Enabled = true;
            tlBtnSave.Enabled = false;
            tlBtnCancel.Enabled = false;
        }
        private void clearText()
        {
            txtTradeCode.Text= string.Empty;
            txtFullName.Text = string.Empty;
            txtType.Text = string.Empty;
            txtStandard.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtProduce.Text = string.Empty;
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
            dgvStockList.Columns[8].HeaderText = "��Ʒ�۸񣨼�Ȩƽ���۸�";
            dgvStockList.Columns[9].Visible = false;
            dgvStockList.Columns[10].HeaderText = "�̵�����";
            dgvStockList.Columns[11].Visible = false;
            dgvStockList.Columns[12].Visible = false;
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            txtTradeCode.ReadOnly = true;��������//��Ʒ���ΪΨһ��ʶ���ܸ���
            this.cancelEnabled();
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void tlBtnSave_Click(object sender, EventArgs e)
        {
            //�ж�����ӻ����޸�����
            if (G_Int_addOrUpdate == 0)
            {
                try
                {
                    //�������
                    stockinfo.TradeCode = txtTradeCode.Text;
                    stockinfo.FullName = txtFullName.Text;
                    stockinfo.TradeType = txtType.Text;
                    stockinfo.Standard = txtStandard.Text;
                    stockinfo.Unit = txtUnit.Text;
                    stockinfo.Produce = txtProduce.Text;

                    //ִ�����
                    int id = baseinfo.AddStock(stockinfo);
                    MessageBox.Show("����--�����Ʒ����--�ɹ���", "�ɹ���ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //�޸�����
                stockinfo.TradeCode = txtTradeCode.Text;
                stockinfo.FullName = txtFullName.Text;
                stockinfo.TradeType = txtType.Text;
                stockinfo.Standard = txtStandard.Text;
                stockinfo.Unit = txtUnit.Text;
                stockinfo.Produce = txtProduce.Text;

                //ִ���޸�
                int id = baseinfo.UpdateStock(stockinfo);
                MessageBox.Show("�޸�--�����Ʒ����--�ɹ���", "�ɹ���ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
            this.cancelEnabled();
        }

        private void tlBtnEdit_Click(object sender, EventArgs e)
        {
            this.editEnabled();
            G_Int_addOrUpdate = 1;   //���ڣ�Ϊ�޸�����
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

        private void tlBtnDelete_Click(object sender, EventArgs e)
        {
            if (txtTradeCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("ɾ��--�����Ʒ����--ʧ�ܣ�", "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            stockinfo.TradeCode = txtTradeCode.Text;
            //ִ��ɾ��
            try
            {
                int id = baseinfo.DeleteStock(stockinfo);
                MessageBox.Show("ɾ��--�����Ʒ����--�ɹ���", "�ɹ���ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvStockList.DataSource = baseinfo.GetAllStock("tb_stock").Tables[0].DefaultView;
                this.SetdgvStockListHeadText();
                this.clearText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlBtnCancel_Click(object sender, EventArgs e)
        {
            this.cancelEnabled();
        }

        private void dgvStockList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTradeCode.Text = this.dgvStockList[0, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtFullName.Text = this.dgvStockList[1, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtType.Text = this.dgvStockList[2, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtStandard.Text = this.dgvStockList[3, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtUnit.Text = this.dgvStockList[4, dgvStockList.CurrentCell.RowIndex].Value.ToString();
            txtProduce.Text = this.dgvStockList[5, dgvStockList.CurrentCell.RowIndex].Value.ToString();
        }

        private void tlBtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}