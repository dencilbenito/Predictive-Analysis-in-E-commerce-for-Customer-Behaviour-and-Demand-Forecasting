using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frm_naivebayes : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            var query = (from u in db.HistoricalDatasets select u.Age_Group).Distinct();
            drop_agegroup.DataSource = query;
            drop_agegroup.DataBind();

            query = (from u in db.HistoricalDatasets select u.Gender).Distinct();
            drop_gender.DataSource = query;
            drop_gender.DataBind();

            query = (from u in db.HistoricalDatasets select u.Locality_Purchased).Distinct();
            drop_locality.DataSource = query;
            drop_locality.DataBind();

            query = (from u in db.HistoricalDatasets select u.Season).Distinct();
            drop_season.DataSource = query;
            drop_season.DataBind();
        }
    }


    protected void btn_predict_Click(object sender, EventArgs e)
    {
        db.ExecuteCommand("delete from Naive_bayes");
        var query = (from u in db.HistoricalDatasets select u.Price_Group).Distinct();
        foreach (var u in query)
        {
            Naive_baye n = new Naive_baye();
            n.PriceGroup_XVariable = u;
            var totcnt = db.HistoricalDatasets.Count();
            Decimal v1,v2,v3,v4,v5 = 0;
            var pgcnt = db.HistoricalDatasets.Where(x => x.Price_Group == u).Count();
            n.Price_Group_AB = Math.Round(Convert.ToDecimal(Convert.ToDecimal(pgcnt) / Convert.ToDecimal(totcnt)), 2);
            v1 = Convert.ToDecimal(Convert.ToDecimal(pgcnt) / Convert.ToDecimal(totcnt));
            var cnt = db.HistoricalDatasets.Where(x => x.Price_Group == u && x.Age_Group == drop_agegroup.Text).Count();
            n.AgeGroup_Vs_PG = Math.Round(Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt)), 2);
            v2 = Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt));
            cnt = db.HistoricalDatasets.Where(x => x.Price_Group == u && x.Gender == drop_gender.Text).Count();
            n.Gender_Vs_PG = Math.Round(Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt)), 2);
            v3 = Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt));
            cnt = db.HistoricalDatasets.Where(x => x.Price_Group == u && x.Locality_Purchased == drop_locality.Text).Count();
            n.Locality_vs_PG = Math.Round(Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt)), 2);
            v4 = Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt));
            cnt = db.HistoricalDatasets.Where(x => x.Price_Group == u && x.Season == drop_season.Text).Count();
            n.Season_vs_PG = Math.Round(Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt)), 2);
            v5 = Convert.ToDecimal(Convert.ToDecimal(cnt) / Convert.ToDecimal(pgcnt));
            n.Naive_bayes = Math.Round(v1 * v2 * v3 * v4 * v5, 5);
            db.Naive_bayes.InsertOnSubmit(n);
            db.SubmitChanges();

            var q = from u1 in db.Naive_bayes select u1;
            GridView1.DataSource = q;
            GridView1.DataBind();

              String s1 = "Naive Bayes Classifier to predict which Price Group will be preferred by the following input values"  + "\n";
              s1 = s1 + "Age Group:" + drop_agegroup.Text + "\n";
              s1 = s1 + "Gender:" + drop_gender.Text + "\n";
              s1 = s1 + "Locality:" + drop_locality.Text + "\n";
              s1 = s1 + "Season:" + drop_season.Text + "\n";


              var q1 = db.Naive_bayes.OrderByDescending(x => x.Naive_bayes).Take(1);
              foreach (var q2 in q1)
              {
                  s1 = s1 + "Predicted Result is:" + q2.PriceGroup_XVariable;
              }
            
              txt_inter.Text = s1;
        }
    }
}