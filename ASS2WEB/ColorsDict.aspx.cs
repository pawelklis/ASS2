using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASS2;

namespace ASS2WEB
{
    public partial class ColorsDict : System.Web.UI.Page
    {
        DictType dict;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDict();
                Bind();
            }
        }

        void GetDict()
        {
      
            dict = DictType.Load<DictType>(1);
        }
        void Bind()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("color");
            dt.Columns.Add("values");
            //dict = new DictType();
            if (dict.Colors == null)
                dict.Colors = new List<ColorType>();


            string vals = "true,false,true,false";

            foreach(var l in dict.Colors)
            {
                string bl = "";
                foreach(var b in l.Values)
                {
                    bl += b.ToString() + ",";
                }


              dt.Rows.Add(l.Name.ToString().ToLower().Replace("color [", "").Replace("]",""),bl);               
            }



            dg1.DataSource = dt;
            dg1.DataBind();

        }

        protected void dg1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType== DataControlRowType.DataRow)
            {
                DropDownList ddlcolor = (DropDownList)e.Row.FindControl("ddlcolor");

                foreach(ColorType.ColorsList c in Enum.GetValues(typeof(ColorType.ColorsList)))
                {
                    ListItem li = new ListItem();
                    li.Value = c.ToString();
                    li.Text = c.ToString();
                    li.Attributes.Add("style", new ColorType(c).CssString());
                    ddlcolor.Items.Add(li);
                }

                string v = ddlcolor.ToolTip;

                foreach(ListItem item in ddlcolor.Items)
                {
                    if (item.Value.ToLower() == v)
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }

                }

                ddlcolor.Attributes.Add("style", new ColorType(ddlcolor.SelectedValue).CssString());

                CheckBoxList ckl = (CheckBoxList)e.Row.FindControl("ckl");

                string[] sb = ckl.ToolTip.Split(',');
                int i = 0;
                foreach(var s in sb)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        ckl.Items[i].Selected = bool.Parse(s);
                    }
                    i++;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<ColorType> l = new List<ColorType>();
            foreach(GridViewRow Row in dg1.Rows)
            {
                DropDownList ddlcolor = (DropDownList)Row.FindControl("ddlcolor");
                CheckBoxList ckl = (CheckBoxList)Row.FindControl("ckl");

                ColorType c = new ColorType(ddlcolor.SelectedValue);
                

                c.Values = new List<bool>();
                foreach(ListItem b in ckl.Items)
                {              
                        c.Values.Add(b.Selected);                    
                }
                l.Add(c);
     
            }

            GetDict();
            dict.Colors = l;
            dict.Save();
            Bind();
        }
    }
}