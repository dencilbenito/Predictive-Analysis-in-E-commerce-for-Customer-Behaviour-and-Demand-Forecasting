using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmdataset : System.Web.UI.Page
{
    dbconnectDataContext db = new dbconnectDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        
        {
            var maxid = db.HistoricalDatasets.OrderByDescending(o => o.Sales_no).Select(s => new { s.Sales_no }).Take(1);

            if (maxid.Count() <= 0)
            {
                txt_salesno.Text = "1";
            }

            foreach (var item in maxid)
            {
                decimal str = item.Sales_no;
                txt_salesno.Text = (str + 1).ToString();
            }

            txt_salesdate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Main Category Names
            var query = db.HistoricalDatasets.Select(x=>x.MainCategory_name).Distinct();
            drop_maincategory.DataSource = query;
            drop_maincategory.DataBind();

            // Sub Category Names
            query = db.HistoricalDatasets.Select(x => x.SubCategory_name).Distinct();
            drop_subcategory.DataSource = query;
            drop_subcategory.DataBind();

            // Brand Name
            query = db.HistoricalDatasets.Select(x => x.Brand_name).Distinct();
            drop_brandname.DataSource = query;
            drop_brandname.DataBind();

            // Product Name
            query = db.HistoricalDatasets.Select(x => x.Product_name).Distinct();
            drop_productname.DataSource = query;
            drop_productname.DataBind();

            // Color Names
            query = db.HistoricalDatasets.Select(x => x.Color_Name).Distinct();
            drop_colorname.DataSource = query;
            drop_colorname.DataBind();

            // Festival
            query = db.HistoricalDatasets.Select(x => x.Festival).Distinct();
            drop_flag.DataSource = query;
            drop_flag.DataBind();

            // festival Names
            query = db.HistoricalDatasets.Select(x => x.Festival_name).Distinct();
            drop_festivalname.DataSource = query;
            drop_festivalname.DataBind();

            // Size Name
            query = db.HistoricalDatasets.Select(x => x.Size_name).Distinct();
            drop_size.DataSource = query;
            drop_size.DataBind();

            // Gender
            query = db.HistoricalDatasets.Select(x => x.Gender).Distinct();
            drop_gender.DataSource = query;
            drop_gender.DataBind();

            // Locality purchased
            query = db.HistoricalDatasets.Select(x => x.Locality_Purchased).Distinct();
            drop_locality.DataSource = query;
            drop_locality.DataBind();

            // age Group names
            query = db.HistoricalDatasets.Select(x => x.Age_Group).Distinct();
            drop_agegroup.DataSource = query;
            drop_agegroup.DataBind();

            //// Month Names
            //query = db.HistoricalDatasets.Select(x => x.Month).Distinct();
            //drop_month.DataSource = query;
            //drop_month.DataBind();

            // Season Names
            query = db.HistoricalDatasets.Select(x => x.Season).Distinct();
            drop_season.DataSource = query;
            drop_season.DataBind();

            // Price Group Names
            query = db.HistoricalDatasets.Select(x => x.Price_Group).Distinct();
            drop_pricegroup.DataSource = query;
            drop_pricegroup.DataBind();

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        HistoricalDataset hd = new HistoricalDataset();
        hd.Sales_no = Convert.ToDecimal(txt_salesno.Text);
        hd.Sales_date = Convert.ToDateTime(txt_salesdate.Text);
        hd.MainCategory_name = drop_maincategory.Text;
        hd.SubCategory_name = drop_subcategory.Text;
        hd.Brand_name = drop_brandname.Text;
        hd.Product_name = drop_productname.Text;
        hd.Qty_Purchased = Convert.ToDecimal(txt_qty.Text);
        hd.Color_Name = drop_colorname.Text;
        hd.Festival_name = drop_festivalname.Text;
        hd.Size_name = drop_size.Text;
        hd.Gender = drop_gender.Text;
        hd.Locality_Purchased = drop_locality.Text;
        hd.Age_Group = drop_agegroup.Text;
        hd.Month = drop_month.Text;
        hd.Season = drop_season.Text;
        hd.Price = Convert.ToDecimal(txt_price.Text);
        hd.Price_Group = drop_pricegroup.Text;
        hd.Rating = Convert.ToDecimal(drop_rating.Text);
        hd.age = Convert.ToDecimal(txt_age.Text);
        hd.Festival = drop_flag.Text;
        db.HistoricalDatasets.InsertOnSubmit(hd);
        db.SubmitChanges();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "<script>alert('Submitted Successfully');</script>");
    }
}