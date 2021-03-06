﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void fileUnits_Click(object sender, EventArgs e)
        {
            BaseInfo.frmUnits frm_units = new EMS.BaseInfo.frmUnits();
            frm_units.Show();
        }

        private void fileStore_Click(object sender, EventArgs e)
        {
            //new EMS.BaseInfo.frmStock().Show();
            //new EMS.Stock.frmLowerLimit().Show();
        }

        private void fileEmployee_Click(object sender, EventArgs e)
        {
            new EMS.BaseInfo.frmEmployee().Show();
        }

        private void fileBuyStock_Click(object sender, EventArgs e)
        {
            //new EMS.BuyStock.frmBuyStock().Show();
            new EMS.BuyStock.frmPurchase().Show();
        }

        private void fileResellStock_Click(object sender, EventArgs e)
        {
            new EMS.SaleStock.frmSalesQuery().Show();
        }

        private void fileRebuyStock_Click(object sender, EventArgs e)
        {
            //new EMS.BuyStock.frmRebuyStock().Show();
        }

        private void fileSellStock_Click(object sender, EventArgs e)
        {
            new EMS.SaleStock.frmSales().Show();
        }

        private void fileBuyStockAnalyse_Click(object sender, EventArgs e)
        {
            //new EMS.BuyStock.frmBuyStockAnalyse().Show();
        }

        private void fileBuyStockSum_Click(object sender, EventArgs e)
        {
            //new EMS.BuyStock.frmBuyStockSum().Show();
        }

        private void fileSellStockSum_Click(object sender, EventArgs e)
        {
            //new EMS.SaleStock.frmSellStockSum().Show();
        }

        private void fileSellStockStatus_Click(object sender, EventArgs e)
        {
            //new EMS.SaleStock.frmSellStockStatus().Show();
        }

        private void fileSellStockOrderBy_Click(object sender, EventArgs e)
        {
            //new EMS.SelectDataDialog.frmSelectOrderby().Show();
        }

        private void fileSellStockCost_Click(object sender, EventArgs e)
        {
            //new EMS.SaleStock.frmSellStockCost().Show();
        }

        private void fileStockStatus_Click(object sender, EventArgs e)
        {
            //new EMS.Stock.frmStockStatus().Show();
        }

        private void fileUpperLimit_Click(object sender, EventArgs e)
        {
           // new EMS.Stock.frmUpperLimit().Show();
        }

        private void fileLowerLimit_Click(object sender, EventArgs e)
        {
            //new EMS.Stock.frmLowerLimit().Show();
            //new EMS.BaseInfo.frmStock().Show();
            EMS.Stock.frmStockCheck frm = new EMS.Stock.frmStockCheck();
            frm.Show();
        }

        private void fileCheckStock_Click(object sender, EventArgs e)
        {
            //new EMS.Stock.frmCheckStock().Show();
        }

        private void 本单位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new EMS.SetSystem.frmUnits().Show();
        }

        private void fileUnitsList_Click(object sender, EventArgs e)
        {
            //new EMS.BuyStock.frmUnitsList().Show();
        }

        private void fileCurrentBook_Click(object sender, EventArgs e)
        {
            //new EMS.BuyStock.frmUnitsList().Show();
        }

        private void fileBakupAndRestor_Click(object sender, EventArgs e)
        {
            //new EMS.SetSystem.frmBakup().Show();
        }

        private void fileClearTable_Click(object sender, EventArgs e)
        {
            //new EMS.SetSystem.frmClearTable().Show();
        }

        private void fileSetOP_Click(object sender, EventArgs e)
        {
            //new EMS.SetSystem.frmSetOP().Show();
        }

        private void frmSysPopedom_Click(object sender, EventArgs e)
        {
           // new EMS.SetSystem.frmSetOP().Show();
        }

        private void fileEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe");
        }

        private void 启动WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WINWORD.EXE");
        }

        private void 启动ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        private void 系统计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void 源码下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://win.51aspx.com/CV/MingriEMS");
        }

        private void tlmBuy_Click(object sender, EventArgs e)
        {

        }

        private void tlmSale_Click(object sender, EventArgs e)
        {

        }

        private void tlmSystem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void 采购信息检索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMS.BuyStock.frmPurchaseQuery p_query = new EMS.BuyStock.frmPurchaseQuery();
            p_query.Show();
        }

        private void 出库操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMS.Stock.frmGoodsOutWaitList frm = new EMS.Stock.frmGoodsOutWaitList();
            frm.Show();
        }

        private void 出库查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMS.Stock.frmOutCheck frm = new EMS.Stock.frmOutCheck();
            frm.Show();
        }

        private void 入库操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMS.Stock.frmGoodsEntryWaitList frm = new EMS.Stock.frmGoodsEntryWaitList();
            frm.Show();
        }

        private void 入库查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMS.Stock.frmEntryCheck frm = new EMS.Stock.frmEntryCheck();
            frm.Show();
        }

    }
}