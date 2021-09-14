using ASS2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASS2WEB
{
    public partial class stands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDG1();
            }
        }

        DictType GetDict()
        {
            DictType dict =DictType.Load<DictType>(1);
            Session["dict"] = dict;
            return dict;
        }
        void BindDG1()
        {
            dg2.DataSource = null;
            dg2.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("lamp1index");
            dt.Columns.Add("lamp2index");
            DictType dict = GetDict();

            foreach (var d in dict.Stands)
            {
                dt.Rows.Add(d.Id, d.Name, d.Lamp1Index,d.Lamp2Index);
            }

            dg1.DataSource = dt;
            dg1.DataBind();

        }

        StandType selectedStand()
        {
            Button btn = (Button)dg1.Rows[dg1.SelectedIndex].FindControl("Button1");
            return GetDict().Stands.Find(x => x.Id == btn.CommandArgument);
        }
        void Binddg2()
        {
            List<StandItemType> l = selectedStand().Items;

            DataTable dt = new DataTable();
            dt.Columns.Add("directionid");
            dt.Columns.Add("color");
            dt.Columns.Add("id");

            foreach (var i in l)
            {
                string dirid = "";
                if(i.Direction != null)
                {
                    if (i.Direction.Id != null)
                    {
                        dirid = i.Direction.Id;
                    }
                }

                string color = "white";
                if(i.Color != null)
                {                
                        color = i.Color.Name.ToString();
                }


                dt.Rows.Add(dirid, color.ToLower().Replace("color [", "").Replace("]", ""),  i.Id);
            }

            dg2.DataSource = dt;
            dg2.DataBind();

        }
        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Savedg1();
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            dg1.SelectedIndex = row.RowIndex;

            if (e.CommandName == "sel")
                Binddg2();
       

        }

        protected void dg2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
      
        }



        protected void dg1save_Click(object sender, EventArgs e)
        {
            Savedg1();
        }

        void Savedg1()
        {
            DictType dict = GetDict();
            foreach (GridViewRow row in dg1.Rows)
            {
                string name = ((Label)row.FindControl("txname")).Text;
                string id = ((Button)row.FindControl("Button1")).CommandArgument;
                int lamp1index= int.Parse(((TextBox)row.FindControl("txlamp1index")).Text);
                int lamp2index = int.Parse(((TextBox)row.FindControl("txlamp2index")).Text);

                StandType dir = dict.Stands.Find(x => x.Id == id);
                dir.Name = name;
                dir.Lamp1Index =lamp1index;
                dir.Lamp2Index = lamp2index;
            }
            dict.Save();
            BindDG1();
        }



        protected void dg2save_Click(object sender, EventArgs e)
        {
            savedg2();
        }

        void savedg2()
        {
            DictType dict = GetDict();
            foreach (GridViewRow row in dg2.Rows)
            {
                string color = ((DropDownList)row.FindControl("ddlcolor")).SelectedValue;
                string id = ((Label)row.FindControl("label6")).ToolTip;
                string directionid = ((DropDownList)row.FindControl("ddldirection")).SelectedValue;

                StandType dir = dict.Stands.Find(x => x.Id == selectedStand().Id);

                StandItemType i = dir.Items.Find(x => x.Id == id);
                i.Color = dict.Colors.Find(x => x.Name.ToString().ToLower() == color.ToLower());
                i.Direction= dict.Directions.Find(x=>x.Id==directionid);


            }
            dict.Save();
            Binddg2();
        }

        protected void dg2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DictType dict = (DictType)Session["dict"];

            if (e.Row.RowType== DataControlRowType.DataRow)
            {
                DropDownList ddlcolor = (DropDownList)e.Row.FindControl("ddlcolor");
                DropDownList ddlDirection = (DropDownList)e.Row.FindControl("ddldirection");

                foreach (ColorType.ColorsList c in Enum.GetValues(typeof(ColorType.ColorsList)))
                {
                    ListItem li = new ListItem();
                    li.Value = c.ToString();
                    li.Text = c.ToString();
                    li.Attributes.Add("style", new ColorType(c).CssString());
                    ddlcolor.Items.Add(li);
                }
                ddlcolor.SelectedValue = ddlcolor.ToolTip;

                Label lb = (Label)e.Row.FindControl("label6");


                ddlDirection.DataSource = dict.Directions;
                ddlDirection.DataTextField = "name";
                ddlDirection.DataValueField = "id";
                ddlDirection.DataBind();

                ddlDirection.Items.Insert(0,new ListItem() { Text = "", Value = "" });


                ddlDirection.SelectedValue = lb.Text;

                ddlcolor.Attributes.Add("style", new ColorType(ddlcolor.SelectedValue).CssString());

            }
        }
    }
}