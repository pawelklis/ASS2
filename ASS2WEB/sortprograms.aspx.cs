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
    public partial class sortprograms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DictType dict = DictType.Load<DictType>(1);
                Session["dict"] = dict;
                BindDG1();
            }
        }
        void BindDG1()
        {
            Button4.Visible = false;
            lbselsp.Text = "0";
            dg2.DataSource = null;
            dg2.DataBind();

            List<SortProgramType> spl = MysqlCore.DB_Main().NewGetObjects<SortProgramType>("select * from sortprograms where machineid=1");
            dg1.DataSource = spl;
            dg1.DataBind();
        }
        void BindDG2(int sortprogramid)
        {
            SortProgramType sp = SortProgramType.Load<SortProgramType>(sortprogramid);

            DataTable dt = new DataTable();
            dt.Columns.Add("standname");
            dt.Columns.Add("directionname");
            dt.Columns.Add("standindex");
            dt.Columns.Add("directionindex");
            dt.Columns.Add("directionid");
            dt.Columns.Add("color");

            Button4.Visible = true;

            foreach(var item in sp.Items)
            {
                dt.Rows.Add("Stanowisko " + (int)(item.StandIndex+1),"Pozycja " + (int)(item.DirectionIndex+1), item.StandIndex, item.DirectionIndex, item.Direction?.Id, item.Color.Name);
            }

            dg2.DataSource = dt;
            dg2.DataBind();

            foreach(GridViewRow row in dg2.Rows)
            {
                if ((row.RowIndex+1) % 7 ==0)
                {
                    foreach(TableCell c in row.Cells)
                    {
                        c.Attributes.Add("style", "border-bottom-color: red;border-bottom-width: 5px; ");
                    }
                }
            }

        }
        void SaveDG1()
        {
            foreach(GridViewRow Row in dg1.Rows)
            {
                string name=((TextBox)Row.FindControl("txname")).Text;
                int Id = int.Parse(((Button)Row.FindControl("Button3")).CommandArgument);
                MysqlCore.DB_Main().ExecuteNonQuery("update sortprograms set name='" + name + "' where id=" + Id);
            }
        }
        void SaveDG2()
        {
            SortProgramType sp = SortProgramType.Load<SortProgramType>(int.Parse(lbselsp.Text));

            DictType dict = DictType.Load<DictType>(1);

            foreach(GridViewRow Row in dg2.Rows)
            {
                string directionId = ((DropDownList)Row.FindControl("ddldirection")).SelectedValue;
                string ColorName = ((DropDownList)Row.FindControl("ddlcolor")).SelectedValue;

                int directionindex = int.Parse(((Label)Row.FindControl("lbdirectionindex")).ToolTip);
                int standindex = int.Parse(((Label)Row.FindControl("lbstandindex")).ToolTip);


                sp.GetItem(standindex, directionindex).Direction = dict.Directions.Find(x => x.Id == directionId);

                foreach(ColorType.ColorsList c in Enum.GetValues(typeof(ColorType.ColorsList)))
                {
                    if (c.ToString() == ColorName)
                    {
                        sp.GetItem(standindex, directionindex).Color = new ColorType(c);
                    }
                }               
            }

            sp.Save();

            BindDG2(sp.Id);
        }
        void AddProgram()
        {
            SortProgramType sp = new SortProgramType(1,"");
            sp.MachineId = 1;
            sp.Save();
            BindDG1();
        }
        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sel")
            {
                lbselsp.Text = e.CommandArgument.ToString();
                BindDG2(int.Parse(e.CommandArgument.ToString()));
            }

            if (e.CommandName == "usun")
            {
                MysqlCore.DB_Main().ExecuteNonQuery("delete from sortprograms where id=" + int.Parse(e.CommandArgument.ToString()));
                BindDG1();
            }
        }

        protected void dg2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType== DataControlRowType.DataRow)
            {
                DropDownList ddldirection = (DropDownList)e.Row.FindControl("ddldirection");
                DropDownList ddlcolor = (DropDownList)e.Row.FindControl("ddlcolor");

                foreach (ColorType.ColorsList c in Enum.GetValues(typeof(ColorType.ColorsList)))
                {
                    if (c.ToString() != "Żółty")
                    {
                        ListItem li = new ListItem();
                        li.Value = c.ToString();
                        li.Text = c.ToString();
                        li.Attributes.Add("style", new ColorType(c).CssString());
                        ddlcolor.Items.Add(li);
                    }

                }
                ddlcolor.SelectedValue = ddlcolor.ToolTip;
                ddlcolor.Attributes.Add("style", new ColorType(ddlcolor.SelectedValue).CssString());

                DictType dict = (DictType)Session["dict"];
                if (dict == null)
                {
                    dict = DictType.Load<DictType>(1);
                    Session["dict"] = dict;
                }


                foreach(var d in dict.Directions)
                {
                    ddldirection.Items.Add(new ListItem() { Text = d.Name, Value = d.Id });
                }
                ddldirection.Items.Insert(0, new ListItem() { Value = "", Text = "" });

                ddldirection.SelectedValue = ddldirection.ToolTip;
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddProgram();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SaveDG1();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SaveDG2();
        }
    }
}