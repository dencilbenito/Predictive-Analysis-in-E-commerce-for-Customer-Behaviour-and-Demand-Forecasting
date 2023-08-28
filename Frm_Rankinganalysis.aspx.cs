using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

public partial class Frm_Rankinganalysis : System.Web.UI.Page
{

    dbconnectDataContext db = new dbconnectDataContext();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
        }
    }


    public void maincategorycode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.MainCategory_name).Select(lg => new { MainCategoryName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.MainCategoryName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.MainCategory_name).Select(lg => new { MainCategoryName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.MainCategoryName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }


        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }


    public void subcategorycode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.SubCategory_name).Select(lg => new { SubCategoryName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.SubCategoryName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.SubCategory_name).Select(lg => new { Subcategoryname = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Subcategoryname;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }


        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void brandnamecode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Brand_name).Select(lg => new { Brandname = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Brandname;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Brand_name).Select(lg => new { BrandName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.BrandName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void productnamecode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Product_name).Select(lg => new { ProductName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.ProductName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Product_name).Select(lg => new { ProductName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.ProductName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }


    public void colornamecode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Color_Name).Select(lg => new { ColorName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.ColorName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Color_Name).Select(lg => new { ColorName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.ColorName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void festivalnamecode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Festival_name).Select(lg => new { FestivalName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.FestivalName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Festival_name).Select(lg => new { FestivalName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.FestivalName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void sizenamecode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Size_name).Select(lg => new { Sizename = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Sizename;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Size_name).Select(lg => new { SizeName = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.SizeName;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void gendercode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Gender).Select(lg => new { Gender = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Gender;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Gender).Select(lg => new { Gender = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Gender;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }


    public void localitypurchasedcode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Locality_Purchased).Select(lg => new { LocalityPurchased = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.LocalityPurchased;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Locality_Purchased).Select(lg => new { LocalityPurchased = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.LocalityPurchased;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void agegroupcode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Age_Group).Select(lg => new { Age_Group = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Age_Group;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Age_Group).Select(lg => new { Age_Group = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Age_Group;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void monthcode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Month).Select(lg => new { Month = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Month;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Month).Select(lg => new { Month = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Month;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void seasoncode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Season).Select(lg => new { Season = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Season;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Season).Select(lg => new { Season = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Season;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void pricegroupcode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Price_Group).Select(lg => new { Price_Group = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Price_Group;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Price_Group).Select(lg => new { Price_Group = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Price_Group;
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    public void Ratingcode()
    {
        if ((txt_from.Text == "") && (txt_to.Text == ""))
        {
            var counts = db.HistoricalDatasets.GroupBy(l => l.Rating).Select(lg => new { Rating = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Rating.ToString();
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }
        else
        {
            var counts = db.HistoricalDatasets.Where(x => x.Sales_date >= Convert.ToDateTime(txt_from.Text) && x.Sales_date <= Convert.ToDateTime(txt_to.Text)).GroupBy(l => l.Rating).Select(lg => new { Rating = lg.Key, TotalSalesVolume = lg.Count() });

            //overall total is d
            decimal d = 0;

            foreach (var u in counts)
            {
                d = d + Convert.ToDecimal(u.TotalSalesVolume);
            }

            foreach (var u in counts)
            {
                MeanRankingTable mt = new MeanRankingTable();
                mt.Variable_name = u.Rating.ToString();
                mt.Variable_Frequency = u.TotalSalesVolume;
                mt.Overall_Value = d;
                mt.Percentage = Math.Round(Convert.ToDecimal((u.TotalSalesVolume / d) * 100), 2);
                mt.Ranking = 0;
                db.MeanRankingTables.InsertOnSubmit(mt);
                db.SubmitChanges();
            }
        }

        var newquery = from s in db.MeanRankingTables orderby s.Variable_Frequency descending select s;
        int seq = 1;
        foreach (var u in newquery)
        {
            var filquery = db.MeanRankingTables.Single(x => x.Variable_name == u.Variable_name);
            filquery.Ranking = seq;
            db.SubmitChanges();
            seq = seq + 1;
        }

        var query = (from s in db.MeanRankingTables orderby s.Ranking ascending select s).Take(8);
        GridView1.DataSource = query;
        GridView1.DataBind();

        Series series = Chart1.Series["Series1"];

        int ser_value = 0;
        foreach (var item in query)
        {
            series.Points.AddXY(item.Variable_name, item.Percentage);
            series.Points[ser_value].Label = item.Percentage.ToString();
            ser_value++;
        }
        Chart1.Titles.Add(drop_criteria.Text + " Wise Ranking");
        Chart1.ChartAreas[0].AxisX.Title = drop_criteria.Text;
        Chart1.ChartAreas[0].AxisY.Title = "Percentage value";
        Chart1.DataSource = query;
        Chart1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        db.ExecuteCommand("delete from MeanRankingTable");

        //Main Category Name
        if (drop_criteria.Text == "MainCategory_name")
        {
            maincategorycode();
        }

        if (drop_criteria.Text == "SubCategory_name")
        {
            subcategorycode();
        }

        if (drop_criteria.Text == "Brand_name")
        {
            brandnamecode();
        }

        if (drop_criteria.Text == "Product_name")
        {
            productnamecode();
        }

         if (drop_criteria.Text == "Color_Name")
        {
            colornamecode();
        }

         if (drop_criteria.Text == "Festival_name")
        {
            festivalnamecode();
        }

        if (drop_criteria.Text == "Size_name")
        {
            sizenamecode();
        }

        if (drop_criteria.Text == "Gender")
        {
            gendercode();
        }

        if (drop_criteria.Text == "Locality_Purchased")
        {
            localitypurchasedcode();
        }

        if (drop_criteria.Text == "Age_Group")
        {
            agegroupcode();
        }

        if (drop_criteria.Text == "Month")
        {
            monthcode();
        }

        if (drop_criteria.Text == "Season")
        {
            seasoncode();
        }

        if (drop_criteria.Text == "Price_Group")
        {
            pricegroupcode();
        }

        if (drop_criteria.Text == "Rating")
        {
            Ratingcode();
        }

        GridView1.DataBind();
          
    }
}