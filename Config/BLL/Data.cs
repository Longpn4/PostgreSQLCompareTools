using Config.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Config.BLL
{
    public class Data
    {
        public static List<Database> listDb = new List<Database>();
        public static List<DatabaseInfo> listDbInfo = new List<DatabaseInfo>();
        public static List<DatabaseInfo> listFileBackup = new List<DatabaseInfo>();

        static DatabaseBLL databaseBLL = new DatabaseBLL();

        public static void createIfNotExistFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void getBangConnection()
        {
            string fileSource = "./Data/database.info";
            if (File.Exists(fileSource))
            {
                string readText = File.ReadAllText(fileSource);
                listDb = JsonConvert.DeserializeObject<List<Database>>(readText);
                listDb = listDb.OrderBy(s => s.Name).ToList();

                Data.listDbInfo = Data.listDb.Select(s => new DatabaseInfo(s)).ToList();
                getAllDbInfo(Data.listDbInfo);
            }
        }

        public static void getAllDbInfo(List<DatabaseInfo> listDatabase)
        {
            foreach (var database in listDatabase)
            {
                databaseBLL.getDatabaseInfo(database, false);

                //Backup lại luôn ngày hôm nay, nếu chưa có
                BackupDatabase(database);
            }
        }

        public static void BackupDatabase(DatabaseInfo database, bool backupOneTimeInDay = true, bool isOpenFile = false)
        {
            if (database != null)
            {
                string folder = "./Data/Backup";
                string obj = JsonConvert.SerializeObject(database);
                if (!backupOneTimeInDay || !Directory.GetFiles(folder).ToList().Exists(a => a.Contains(database.Name + "_" + DateTime.Now.ToString("dd_MM_yyyy"))))
                {
                    var file = folder + "/" + database.Name + "_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt";
                    System.IO.File.WriteAllText(file, obj);

                    if (isOpenFile)
                    {
                        //Open folder và select file
                        Process.Start("explorer.exe", "/select, " + Path.GetFullPath(file));
                    }
                }
            }
        }

        public static void getListFileBackup()
        {
            Data.listFileBackup = new List<DatabaseInfo>();
            string folder = "./Data/Backup/";
            var files = Directory.GetFiles(folder);
            if (files != null && files.Count() > 0)
            {
                foreach (var file in files)
                {
                    try
                    {
                        string readText = File.ReadAllText(file);
                        var response = JsonConvert.DeserializeObject<DatabaseInfo>(readText);

                        response.ListTable.ForEach(table => table.ListComment = table.ListComment.OrderBy(c => c.ColumnName).ToList());
                        response.ListTable.ForEach(table => GenerateSQL.generateCodeCreateTable(table));

                        response.Name = new FileInfo(file).Name;
                        Data.listFileBackup.Add(response);
                    }
                    catch { }
                }
            }

            Data.listFileBackup = Data.listFileBackup.OrderBy(s => s.Name).ToList();
        }

        public static bool RefreshOnlyDatabase(DatabaseInfo database)
        {
            bool flag = false;
            try
            {
                flag = databaseBLL.getDatabaseInfo(database, false);
                //cboDatabase.setDataSource(Data.listDbInfo, "Name");
                //cboDb.setDataSource(Data.listDbInfo, "Name");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return flag;
        }

        public static void BackupTree(TreeView treeNode)
        {
            try
            {
                if (treeNode != null)
                {
                    //string obj = JsonConvert.SerializeObject(treeNode);
                    var file = "./Data/Backup/treeConnection1.cofig";
                    DatabaseNode databaseNode = getDataNode((TreeNodeConnection)treeNode.Nodes[0]);
                    string obj = JsonConvert.SerializeObject(databaseNode);
                    System.IO.File.WriteAllText(file, obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void LoadTree(TreeView treeNode, string file)
        {
            try
            {
                if (File.Exists(file))
                {
                    string readText = File.ReadAllText(file);
                    DatabaseNode databaseNode = JsonConvert.DeserializeObject<DatabaseNode>(readText);
                    if (databaseNode != null)
                    {
                        treeNode.Nodes.Add(getNode(databaseNode));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static TreeNodeConnection getNode(DatabaseNode databaseNode)
        {
            if (databaseNode.ImageIndex == Constant.Img_ConnectionSuccess)
            {
                databaseNode.ImageIndex = Constant.Img_NewConnection;
                databaseNode.SelectedImageIndex = Constant.Img_NewConnection;
            }

            TreeNodeConnection node = new TreeNodeConnection(databaseNode.Text, databaseNode.ImageIndex, databaseNode.SelectedImageIndex);
            node.Description = databaseNode.Description;
            node.Connection = databaseNode.Connection;
            if (databaseNode.ListNode.Count > 0)
            {
                foreach (var db in databaseNode.ListNode)
                {
                    node.Nodes.Add(getNode(db));
                }
            }

            return node;
        }

        public static DatabaseNode getDataNode(TreeNodeConnection node)
        {
            DatabaseNode databaseNode = new DatabaseNode();
            databaseNode.Text = node.Text;
            databaseNode.Description = node.Description;
            databaseNode.Connection = node.Connection;
            databaseNode.ImageIndex = node.ImageIndex;
            databaseNode.ListNode = new List<DatabaseNode>();
            databaseNode.SelectedImageIndex = node.SelectedImageIndex;
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNodeConnection item in node.Nodes)
                {
                    databaseNode.ListNode.Add(getDataNode(item));
                }
            }

            return databaseNode;
        }

        public static void initData()
        {
            initFolder();
        }

        public static void initFolder()
        {
            Data.createIfNotExistFolder("./Data");
            Data.createIfNotExistFolder("./Data/Backup");
        }
    }
}
