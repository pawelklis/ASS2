using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ASS2;

namespace ASS2WEB
{
    public partial class directions : System.Web.UI.Page
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
            return DictType.Load<DictType>(1);
        }
        void BindDG1()
        {

            dg2add.Visible = false;
            dg2save.Visible = false;

            dg2.DataSource = null;
            dg2.DataBind();

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Columns.Add("idmachine");
            DictType dict = GetDict();
            
            foreach(var d in dict.Directions)
            {
                dt.Rows.Add(d.Id, d.Name, d.IdMachine);
            }

            dg1.DataSource = dt;
            dg1.DataBind();

            return;

            var file = System.IO.File.ReadAllLines(@"C:\Users\klispawel\Downloads\test.csv");

            DictType dd = GetDict();
            dd.Directions.Clear();
 string[] ss = file;
            try
            {
                foreach(var s in ss)
                {

                    string nazwa ="KOM_" + s.Split(';')[0];
                    string zakresy = s.Split(';')[1];


                    DirectionType d = new DirectionType() { IdMachine = 1, Name = nazwa };

                    foreach(var z in zakresy.Split(','))
                    {

                        string z1 = z.Split('-')[0];
                        string z2 = z1;
                        try
                        {
                             z2 = z.Split('-')[1];
                        }
                        catch (Exception)
                        {

                            
                        }
            

                        d.Items.Add(new DirectionItemType() { PnaFrom = z1, PnaTo = z2 });
     
                    }
                   dd.Directions.Add(d);

                }
            }
            catch (Exception)
            {

               
            }


            dd.Save();
        }

        DirectionType selecteddirection()
        {
            Button btn = (Button)dg1.Rows[dg1.SelectedIndex].FindControl("Button1");
            return GetDict().Directions.Find(x => x.Id == btn.CommandArgument);
        }
        void Binddg2()
        {
            dg2add.Visible = true;
            dg2save.Visible = true;
            List<DirectionItemType> l = selecteddirection().Items;

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("wsr");
            dt.Columns.Add("pnafrom");
            dt.Columns.Add("pnato");
            dt.Columns.Add("id");
            dt.Columns.Add("parceltypes");

            foreach(var i in l)
            {
                dt.Rows.Add(i.Name, i.WSR, i.PnaFrom, i.PnaTo, i.Id,i.ParcelTypes);
            }

            dg2.DataSource = dt;
            dg2.DataBind();

        }
        protected void dg1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Savedg1();
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            dg1.SelectedIndex  = row.RowIndex;

            if(e.CommandName=="sel")
                Binddg2();
            if (e.CommandName == "del")
            {
                DictType dict = GetDict();

                foreach(var d in dict.Directions)
                {
                    if (d.Id == e.CommandArgument.ToString())
                    {
                        dict.Directions.Remove(d);
                        dict.Save();
                        break;
                    }
                }

                BindDG1();
            }

        }

        protected void dg2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            savedg2();
            DictType dict = GetDict();
            DirectionType seldir = selecteddirection();

            foreach (var d in dict.Directions)
            {
                if (d.Id == seldir.Id)
                {
                    foreach(var i in d.Items)
                    {
                        if (i.Id == e.CommandArgument.ToString())
                        {
                            d.Items.Remove(i);
                            dict.Save();
                            Binddg2();

                            break;
                        }
                    }

                }
            }

        }

        protected void dg1add_Click(object sender, EventArgs e)
        {
            Savedg1();
            DictType dict = GetDict();

            dict.Directions.Add(new DirectionType());
            dict.Save();
            BindDG1();          

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
                string name = ((TextBox)row.FindControl("txname")).Text;
                string id = ((Button)row.FindControl("Button1")).CommandArgument;

                DirectionType dir = dict.Directions.Find(x => x.Id == id);
                dir.Name = name;
            }
            dict.Save();
            BindDG1();
        }

        protected void dg2add_Click(object sender, EventArgs e)
        {
            savedg2();
            DictType dict = GetDict();

            dict.Directions.Find(x=>x.Id==selecteddirection().Id).Items.Add(new DirectionItemType() { ParcelTypes = "LW,LWPR,B,PXN,PP1,PPLUS,UK,P,PPR,BPR,PW,PP,PP2,PWPR,UP" });
            dict.Save();
            Binddg2();
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
                string name = ((TextBox)row.FindControl("txname")).Text;
                string id = ((Button)row.FindControl("Button2")).CommandArgument;
                string wsr= ((TextBox)row.FindControl("txwsr")).Text;
                string pnafrom= ((TextBox)row.FindControl("txpnafrom")).Text;
                string pnato= ((TextBox)row.FindControl("txpnato")).Text;
                string parceltyp = ((TextBox)row.FindControl("txpt")).Text;
                DirectionType dir = dict.Directions.Find(x => x.Id == selecteddirection().Id);

                DirectionItemType i = dir.Items.Find(x => x.Id == id);
                i.Name = name;
                i.WSR = wsr;
                i.PnaFrom = pnafrom;
                i.PnaTo = pnato;
                i.ParcelTypes = parceltyp;


            }
            dict.Save();
            Binddg2();
        }
    }
}