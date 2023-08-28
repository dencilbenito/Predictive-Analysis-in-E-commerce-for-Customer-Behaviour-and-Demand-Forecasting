using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_knn : System.Web.UI.Page
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
        try
        {
            //K-value calculation
            var kvalue = db.HistoricalDatasets.Select(l => l.MainCategory_name).Distinct().Count();
            lbl_kvalue.Text = kvalue.ToString();

            db.ExecuteCommand("delete from knn_filter");

            //Calculating Euclidean distance
            var ed = from d in db.HistoricalDatasets where d.Sales_date >= Convert.ToDateTime(txt_from.Text) && d.Sales_date <= Convert.ToDateTime(txt_to.Text) select d;
            foreach (var u in ed)
            {
                double x1 = Convert.ToDouble(txt_age.Text);
                double x2 = Convert.ToDouble(u.age);
                double y1 = 1;
                double y2 = 0;
                if (u.Gender == drop_gender.Text)
                {
                    y2 = 1;
                }

                knn_filter kf = new knn_filter();
                kf.Sales_no = Convert.ToDecimal(u.Sales_no);
                kf.Distance = Convert.ToDecimal(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
                kf.Variable_heading = drop_criteria.Text;
                kf.Variable_name = u.MainCategory_name;
                db.knn_filters.InsertOnSubmit(kf);
                db.SubmitChanges();
            }
            db.ExecuteCommand("delete from variableTable");

            var list = (from t in db.knn_filters orderby t.Distance ascending select t).Take(kvalue);
            foreach (var u in list)
            {
                var q = db.variableTables.SingleOrDefault(x => x.variable_name == u.Variable_name);
                if (q == null)
                {
                    variableTable vt = new variableTable();
                    vt.variable_name = u.Variable_name;
                    vt.variable_count = 1;
                    db.variableTables.InsertOnSubmit(vt);
                    db.SubmitChanges();

                }

                else
                {
                    q.variable_count = Convert.ToDecimal(q.variable_count) + 1;
                    db.SubmitChanges();
                }
            }

            GridView1.DataSource = list;
            GridView1.DataBind();

            var fknn = from u in db.variableTables orderby u.variable_count descending select u;
            GridView2.DataSource = fknn;
            GridView2.DataBind();
            
        }

        catch (Exception ex)
        {
        }
    }



    public void subcategorycode()
    {
        try
        {
            //K-value calculation
            var kvalue = db.HistoricalDatasets.Select(l => l.SubCategory_name).Distinct().Count();
            lbl_kvalue.Text = kvalue.ToString();

            db.ExecuteCommand("delete from knn_filter");

            //Calculating Euclidean distance
            var ed = from d in db.HistoricalDatasets where d.Sales_date >= Convert.ToDateTime(txt_from.Text) && d.Sales_date <= Convert.ToDateTime(txt_to.Text) select d;
            foreach (var u in ed)
            {
                double x1 = Convert.ToDouble(txt_age.Text);
                double x2 = Convert.ToDouble(u.age);
                double y1 = 1;
                double y2 = 0;
                if (u.Gender == drop_gender.Text)
                {
                    y2 = 1;
                }

                knn_filter kf = new knn_filter();
                kf.Sales_no = Convert.ToDecimal(u.Sales_no);
                kf.Distance = Convert.ToDecimal(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
                kf.Variable_heading = drop_criteria.Text;
                kf.Variable_name = u.SubCategory_name;
                db.knn_filters.InsertOnSubmit(kf);
                db.SubmitChanges();
            }
            db.ExecuteCommand("delete from variableTable");

            var list = (from t in db.knn_filters orderby t.Distance ascending select t).Take(kvalue);
            foreach (var u in list)
            {
                var q = db.variableTables.SingleOrDefault(x => x.variable_name == u.Variable_name);
                if (q == null)
                {
                    variableTable vt = new variableTable();
                    vt.variable_name = u.Variable_name;
                    vt.variable_count = 1;
                    db.variableTables.InsertOnSubmit(vt);
                    db.SubmitChanges();

                }

                else
                {
                    q.variable_count = Convert.ToDecimal(q.variable_count) + 1;
                    db.SubmitChanges();
                }
            }

            GridView1.DataSource = list;
            GridView1.DataBind();

            var fknn = from u in db.variableTables orderby u.variable_count descending select u;
            GridView2.DataSource = fknn;
            GridView2.DataBind();

        }

        catch (Exception ex)
        {
        }
    }


    protected void btn_ec_Click(object sender, EventArgs e)
    {

        try
        {
            //K-value calculation
            if (drop_criteria.Text == "MainCategory_name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.MainCategory_name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "SubCategory_name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.SubCategory_name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Brand_name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Brand_name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Product_name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Product_name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Color_Name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Color_Name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Festival_name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Festival_name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Size_name")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Size_name).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Gender")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Gender).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Locality_Purchased")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Locality_Purchased).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Age_Group")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Age_Group).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Month")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Month).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Season")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Season).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

            if (drop_criteria.Text == "Price_Group")
            {
                var kvalue = db.HistoricalDatasets.Select(l => l.Price_Group).Distinct().Count();
                lbl_kvalue.Text = kvalue.ToString();
            }

           

            db.ExecuteCommand("delete from knn_filter");

            //Calculating Euclidean distance
            var ed = from d in db.HistoricalDatasets where d.Sales_date >= Convert.ToDateTime(txt_from.Text) && d.Sales_date <= Convert.ToDateTime(txt_to.Text) select d;
            foreach (var u in ed)
            {
                double x1 = Convert.ToDouble(txt_age.Text);
                double x2 = Convert.ToDouble(u.age);
                double y1 = 1;
                double y2 = 0;
                if (u.Gender == drop_gender.Text)
                {
                    y2 = 1;
                }

                knn_filter kf = new knn_filter();
                kf.Sales_no = Convert.ToDecimal(u.Sales_no);
                kf.Distance = Convert.ToDecimal(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
                kf.Variable_heading = drop_criteria.Text;

                if (drop_criteria.Text == "MainCategory_name")
                {
                    kf.Variable_name = u.MainCategory_name;
                }

                if (drop_criteria.Text == "SubCategory_name")
                {
                    kf.Variable_name = u.SubCategory_name;
                }

                if (drop_criteria.Text == "Brand_name")
                {
                    kf.Variable_name = u.Brand_name;
                }

                if (drop_criteria.Text == "Product_name")
                {
                    kf.Variable_name = u.Product_name;
                }

                if (drop_criteria.Text == "Color_Name")
                {
                    kf.Variable_name = u.Color_Name;
                }

                if (drop_criteria.Text == "Festival_name")
                {
                    kf.Variable_name = u.Festival_name;
                }

                if (drop_criteria.Text == "Size_name")
                {
                    kf.Variable_name = u.Size_name;
                }

                if (drop_criteria.Text == "Gender")
                {
                    kf.Variable_name = u.Gender;
                }

                if (drop_criteria.Text == "Locality_Purchased")
                {
                    kf.Variable_name = u.Locality_Purchased;
                }

                if (drop_criteria.Text == "Age_Group")
                {
                    kf.Variable_name = u.Age_Group;
                }

                if (drop_criteria.Text == "Month")
                {
                    kf.Variable_name = u.Month;
                }

                if (drop_criteria.Text == "Season")
                {
                    kf.Variable_name = u.Season;
                }

                if (drop_criteria.Text == "Price_Group")
                {
                    kf.Variable_name = u.Price_Group;
                }



                db.knn_filters.InsertOnSubmit(kf);
                db.SubmitChanges();
            }
            db.ExecuteCommand("delete from variableTable");

            var list = (from t in db.knn_filters orderby t.Distance ascending select t).Take(Convert.ToInt16(lbl_kvalue.Text));
            foreach (var u in list)
            {
                var q = db.variableTables.SingleOrDefault(x => x.variable_name == u.Variable_name);
                if (q == null)
                {
                    variableTable vt = new variableTable();
                    vt.variable_name = u.Variable_name;
                    vt.variable_count = 1;
                    db.variableTables.InsertOnSubmit(vt);
                    db.SubmitChanges();

                }

                else
                {
                    q.variable_count = Convert.ToDecimal(q.variable_count) + 1;
                    db.SubmitChanges();
                }
            }

            GridView1.DataSource = list;
            GridView1.DataBind();


            String t1 = "Best Fit : ";

            var fknn = from u in db.variableTables orderby u.variable_count descending select u;
            foreach (var u in fknn)
            {
                t1 = t1 + u.variable_name + "(" + u.variable_count + "),";

            }
            GridView2.DataSource = fknn;
            GridView2.DataBind();

            txt_inference.Text = t1.ToString();
        }

        catch (Exception ex)
        {
        }


       

        

       // GridView1.DataBind();
    }
}