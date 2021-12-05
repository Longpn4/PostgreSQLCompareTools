using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Collections.Generic;
using System.Reflection;
using FastColoredTextBoxNS;
using FarsiLibrary.Win;
using System.IO;
using System.Text.RegularExpressions;
using Config.BLL;
using Config.Model;

namespace SqlCompare
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class FrmSupportSql : System.Windows.Forms.Form
    {
        Style invisibleCharsStyle = new InvisibleCharsRenderer(Pens.Red);
        Color currentLineColor = Color.FromArgb(100, 210, 210, 255);
        Color changedLineColor = Color.FromArgb(255, 230, 230, 255);
        private Style sameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Gray)));
        TreeNodeConnection NodeA = null;
        TreeNodeConnection NodeB = null;
        WaitWndFun waitForm = WaitWndFun.GetInstance();

        #region
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManager1;
        private DevComponents.DotNetBar.DockSite barLeftDockSite;
        private DevComponents.DotNetBar.DockSite barRightDockSite;
        private DevComponents.DotNetBar.DockSite barTopDockSite;
        private DevComponents.DotNetBar.DockSite barBottomDockSite;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private int m_DocumentCount = 0;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.Bar mainmenu;
        private DevComponents.DotNetBar.ButtonItem item_67;
        private DevComponents.DotNetBar.ButtonItem item_78;
        private DevComponents.DotNetBar.ButtonItem item_89;
        private DevComponents.DotNetBar.ButtonItem item_100;
        private DevComponents.DotNetBar.ButtonItem item_111;
        private DevComponents.DotNetBar.ButtonItem item_122;
        private DevComponents.DotNetBar.ButtonItem item_133;
        private DevComponents.DotNetBar.ButtonItem item_144;
        private DevComponents.DotNetBar.ButtonItem item_155;
        private DevComponents.DotNetBar.ButtonItem item_166;
        private DevComponents.DotNetBar.ButtonItem item_167;
        private DevComponents.DotNetBar.ButtonItem item_237;
        private DevComponents.DotNetBar.ButtonItem item_248;
        private DevComponents.DotNetBar.ButtonItem item_259;
        private DevComponents.DotNetBar.ButtonItem item_270;
        private DevComponents.DotNetBar.ButtonItem item_281;
        private DevComponents.DotNetBar.ButtonItem item_292;
        private DevComponents.DotNetBar.ButtonItem item_303;
        private DevComponents.DotNetBar.Bar barConnections;
        private DevComponents.DotNetBar.DockContainerItem dSolutionExplorer;
        private DevComponents.DotNetBar.DockContainerItem dSolutionProperties;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer3;
        private DevComponents.DotNetBar.PanelDockContainer panelDockContainer4;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TreeView treeConnection;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnAddNewConnect;
        private DevComponents.DotNetBar.ButtonItem btnAddNewFolder;
        private DevComponents.DotNetBar.ButtonItem item_299;
        public PropertyGrid propertyGrid1;
        private Bar barProperty;
        private ButtonItem buttonChangeStyle;
        private ButtonItem buttonStyleMetro;
        private ButtonItem buttonStyleOffice2010Blue;
        private ButtonItem buttonStyleOffice2010Silver;
        private ButtonItem buttonStyleOffice2010Black;
        private ButtonItem buttonStyleVS2010;
        private ButtonItem buttonItem62;
        private ButtonItem buttonStyleOffice2007Blue;
        private ButtonItem buttonStyleOffice2007Black;
        private ButtonItem buttonStyleOffice2007Silver;
        private ButtonItem buttonItem60;
        private ColorPickerDropDown buttonStyleCustom;
        private DockContainerItem dConnections;
        private ContextMenuStrip contextConnection;
        private ToolStripMenuItem btnConnect;
        private ToolStripMenuItem btnDupplicate;
        private ToolStripMenuItem btnDelete;
        private ToolStripMenuItem btnNewConnection;
        private ToolStripMenuItem btnNewFolder;
        private ButtonItem btnExpandFolder;
        private ButtonItem btnCollapseFolder;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem btnRename;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStrip tsMain;
        private ToolStripButton newToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton cutToolStripButton;
        private ToolStripButton copyToolStripButton;
        private ToolStripButton pasteToolStripButton;
        private ToolStripButton btInvisibleChars;
        private ToolStripButton btHighlightCurrentLine;
        private ToolStripButton btShowFoldingLines;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton undoStripButton;
        private ToolStripButton redoStripButton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton backStripButton;
        private ToolStripButton forwardStripButton;
        private ToolStripTextBox tbFind;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton bookmarkPlusButton;
        private ToolStripButton bookmarkMinusButton;
        private ToolStripDropDownButton gotoButton;
        private Bar barMenu;
        private ButtonItem buttonItem1;
        private ButtonItem btnNewConnectionMenu;
        private ButtonItem btnNewFolderMenu;
        private FarsiLibrary.Win.FATabStrip tsFiles;
        private ContextMenuStrip cmMain;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem findToolStripMenuItem;
        private ToolStripMenuItem replaceToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem autoIndentSelectedTextToolStripMenuItem;
        private ToolStripMenuItem commentSelectedToolStripMenuItem;
        private ToolStripMenuItem uncommentSelectedToolStripMenuItem;
        private ToolStripMenuItem cloneLinesToolStripMenuItem;
        private ToolStripMenuItem cloneLinesAndCommentToolStripMenuItem;
        private ImageList listImagecon;
        private OpenFileDialog ofdMain;
        private SaveFileDialog sfdMain;
        private ToolStripMenuItem btnRefresh;
        private ToolStripMenuItem btnDisconnect;
        private ButtonItem buttonItem2;
        private ButtonItem buttonItem3;
        private ButtonItem buttonItem4;
        private ButtonItem btnConnections;
        private ButtonItem btnConfig;
        private ButtonItem btnAppendString;
        private ButtonItem btnGenerateSql;
        private ButtonItem btnAbout;
        private ButtonItem btnDeleteConnection;
        private ButtonItem btnRenameConnection;
        private ButtonItem btnDupplicateConnection;
        private ToolStripMenuItem btnCompare;
        private ToolStripMenuItem btnSelectLeftConnection;
        private FastColoredTextBox txtSyncResult;
        private Bar barResult;
        private PanelDockContainer panelDockContainerResult;
        private DockContainerItem dockContainerItem1;
        private int m_UniqueBarCount = 0;
        #endregion

        public FrmSupportSql()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupportSql));
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.barResult = new DevComponents.DotNetBar.Bar();
            this.panelDockContainerResult = new DevComponents.DotNetBar.PanelDockContainer();
            this.txtSyncResult = new FastColoredTextBoxNS.FastColoredTextBox();
            this.dockContainerItem1 = new DevComponents.DotNetBar.DockContainerItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barConnections = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer3 = new DevComponents.DotNetBar.PanelDockContainer();
            this.treeConnection = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnAddNewConnect = new DevComponents.DotNetBar.ButtonItem();
            this.btnAddNewFolder = new DevComponents.DotNetBar.ButtonItem();
            this.item_299 = new DevComponents.DotNetBar.ButtonItem();
            this.btnExpandFolder = new DevComponents.DotNetBar.ButtonItem();
            this.btnCollapseFolder = new DevComponents.DotNetBar.ButtonItem();
            this.dConnections = new DevComponents.DotNetBar.DockContainerItem();
            this.barProperty = new DevComponents.DotNetBar.Bar();
            this.panelDockContainer4 = new DevComponents.DotNetBar.PanelDockContainer();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.dSolutionProperties = new DevComponents.DotNetBar.DockContainerItem();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.barMenu = new DevComponents.DotNetBar.Bar();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewConnectionMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnNewFolderMenu = new DevComponents.DotNetBar.ButtonItem();
            this.btnDeleteConnection = new DevComponents.DotNetBar.ButtonItem();
            this.btnRenameConnection = new DevComponents.DotNetBar.ButtonItem();
            this.btnDupplicateConnection = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.btnConnections = new DevComponents.DotNetBar.ButtonItem();
            this.btnConfig = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.btnAppendString = new DevComponents.DotNetBar.ButtonItem();
            this.btnGenerateSql = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.btnAbout = new DevComponents.DotNetBar.ButtonItem();
            this.mainmenu = new DevComponents.DotNetBar.Bar();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.btInvisibleChars = new System.Windows.Forms.ToolStripButton();
            this.btHighlightCurrentLine = new System.Windows.Forms.ToolStripButton();
            this.btShowFoldingLines = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.backStripButton = new System.Windows.Forms.ToolStripButton();
            this.forwardStripButton = new System.Windows.Forms.ToolStripButton();
            this.tbFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bookmarkPlusButton = new System.Windows.Forms.ToolStripButton();
            this.bookmarkMinusButton = new System.Windows.Forms.ToolStripButton();
            this.gotoButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.item_67 = new DevComponents.DotNetBar.ButtonItem();
            this.item_78 = new DevComponents.DotNetBar.ButtonItem();
            this.item_89 = new DevComponents.DotNetBar.ButtonItem();
            this.item_100 = new DevComponents.DotNetBar.ButtonItem();
            this.item_111 = new DevComponents.DotNetBar.ButtonItem();
            this.item_122 = new DevComponents.DotNetBar.ButtonItem();
            this.item_133 = new DevComponents.DotNetBar.ButtonItem();
            this.item_144 = new DevComponents.DotNetBar.ButtonItem();
            this.item_155 = new DevComponents.DotNetBar.ButtonItem();
            this.item_166 = new DevComponents.DotNetBar.ButtonItem();
            this.item_167 = new DevComponents.DotNetBar.ButtonItem();
            this.item_237 = new DevComponents.DotNetBar.ButtonItem();
            this.item_248 = new DevComponents.DotNetBar.ButtonItem();
            this.item_259 = new DevComponents.DotNetBar.ButtonItem();
            this.item_270 = new DevComponents.DotNetBar.ButtonItem();
            this.item_281 = new DevComponents.DotNetBar.ButtonItem();
            this.item_292 = new DevComponents.DotNetBar.ButtonItem();
            this.item_303 = new DevComponents.DotNetBar.ButtonItem();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.buttonChangeStyle = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleMetro = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2010Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleVS2010 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem62 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Blue = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Black = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleOffice2007Silver = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem60 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonStyleCustom = new DevComponents.DotNetBar.ColorPickerDropDown();
            this.contextConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectLeftConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDupplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRename = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFiles = new FarsiLibrary.Win.FATabStrip();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.autoIndentSelectedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncommentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesAndCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listImagecon = new System.Windows.Forms.ImageList(this.components);
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.barBottomDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barResult)).BeginInit();
            this.barResult.SuspendLayout();
            this.panelDockContainerResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyncResult)).BeginInit();
            this.barLeftDockSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barConnections)).BeginInit();
            this.barConnections.SuspendLayout();
            this.panelDockContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barProperty)).BeginInit();
            this.barProperty.SuspendLayout();
            this.panelDockContainer4.SuspendLayout();
            this.dockSite4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainmenu)).BeginInit();
            this.mainmenu.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.contextConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsFiles)).BeginInit();
            this.cmMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
            this.dotNetBarManager1.Images = this.imageList1;
            this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
            this.dotNetBarManager1.ParentForm = this;
            this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite5;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite3;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite4;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
            this.dotNetBarManager1.ItemClick += new System.EventHandler(this.dotNetBarManager1_ItemClick);
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Controls.Add(this.barResult);
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.barResult, 939, 95)))}, DevComponents.DotNetBar.eOrientation.Vertical);
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 486);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(939, 98);
            this.barBottomDockSite.TabIndex = 4;
            this.barBottomDockSite.TabStop = false;
            // 
            // barResult
            // 
            this.barResult.AccessibleDescription = "DotNetBar Bar (barResult)";
            this.barResult.AccessibleName = "DotNetBar Bar";
            this.barResult.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.barResult.AutoSyncBarCaption = true;
            this.barResult.CloseSingleTab = true;
            this.barResult.Controls.Add(this.panelDockContainerResult);
            this.barResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barResult.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.barResult.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dockContainerItem1});
            this.barResult.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.barResult.Location = new System.Drawing.Point(0, 3);
            this.barResult.Name = "barResult";
            this.barResult.Size = new System.Drawing.Size(939, 95);
            this.barResult.Stretch = true;
            this.barResult.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.barResult.TabIndex = 0;
            this.barResult.TabStop = false;
            this.barResult.Text = "dockContainerItem1";
            // 
            // panelDockContainerResult
            // 
            this.panelDockContainerResult.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.panelDockContainerResult.Controls.Add(this.txtSyncResult);
            this.panelDockContainerResult.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainerResult.Name = "panelDockContainerResult";
            this.panelDockContainerResult.Size = new System.Drawing.Size(933, 69);
            this.panelDockContainerResult.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainerResult.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainerResult.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainerResult.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainerResult.Style.GradientAngle = 90;
            this.panelDockContainerResult.TabIndex = 0;
            // 
            // txtSyncResult
            // 
            this.txtSyncResult.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtSyncResult.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.txtSyncResult.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.txtSyncResult.BackBrush = null;
            this.txtSyncResult.CharHeight = 14;
            this.txtSyncResult.CharWidth = 8;
            this.txtSyncResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSyncResult.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSyncResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSyncResult.IsReplaceMode = false;
            this.txtSyncResult.Location = new System.Drawing.Point(0, 0);
            this.txtSyncResult.Name = "txtSyncResult";
            this.txtSyncResult.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSyncResult.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSyncResult.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtSyncResult.ServiceColors")));
            this.txtSyncResult.Size = new System.Drawing.Size(933, 69);
            this.txtSyncResult.TabIndex = 1;
            this.txtSyncResult.Zoom = 100;
            // 
            // dockContainerItem1
            // 
            this.dockContainerItem1.Control = this.panelDockContainerResult;
            this.dockContainerItem1.Name = "dockContainerItem1";
            this.dockContainerItem1.Text = "dockContainerItem1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Controls.Add(this.barConnections);
            this.barLeftDockSite.Controls.Add(this.barProperty);
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer(new DevComponents.DotNetBar.DocumentBaseContainer[] {
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.barConnections, 291, 193))),
            ((DevComponents.DotNetBar.DocumentBaseContainer)(new DevComponents.DotNetBar.DocumentBarContainer(this.barProperty, 291, 240)))}, DevComponents.DotNetBar.eOrientation.Vertical);
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 50);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(294, 436);
            this.barLeftDockSite.TabIndex = 1;
            this.barLeftDockSite.TabStop = false;
            // 
            // barConnections
            // 
            this.barConnections.AccessibleDescription = "DotNetBar Bar (barConnections)";
            this.barConnections.AccessibleName = "DotNetBar Bar";
            this.barConnections.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.barConnections.AutoHideAnimationTime = 0;
            this.barConnections.AutoSyncBarCaption = true;
            this.barConnections.CanDockTop = false;
            this.barConnections.CanHide = true;
            this.barConnections.CloseSingleTab = true;
            this.barConnections.Controls.Add(this.panelDockContainer3);
            this.barConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barConnections.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.barConnections.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dConnections});
            this.barConnections.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.barConnections.Location = new System.Drawing.Point(0, 0);
            this.barConnections.Name = "barConnections";
            this.barConnections.SingleLineColor = System.Drawing.SystemColors.ActiveCaption;
            this.barConnections.Size = new System.Drawing.Size(291, 193);
            this.barConnections.Stretch = true;
            this.barConnections.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.barConnections.TabIndex = 0;
            this.barConnections.TabStop = false;
            this.barConnections.Text = "Connections";
            // 
            // panelDockContainer3
            // 
            this.panelDockContainer3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.panelDockContainer3.Controls.Add(this.treeConnection);
            this.panelDockContainer3.Controls.Add(this.bar1);
            this.panelDockContainer3.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer3.Name = "panelDockContainer3";
            this.panelDockContainer3.Size = new System.Drawing.Size(285, 167);
            this.panelDockContainer3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelDockContainer3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer3.Style.GradientAngle = 90;
            this.panelDockContainer3.TabIndex = 1;
            // 
            // treeConnection
            // 
            this.treeConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeConnection.HotTracking = true;
            this.treeConnection.ImageIndex = 7;
            this.treeConnection.ImageList = this.imageList2;
            this.treeConnection.ItemHeight = 18;
            this.treeConnection.Location = new System.Drawing.Point(0, 28);
            this.treeConnection.Name = "treeConnection";
            this.treeConnection.SelectedImageIndex = 0;
            this.treeConnection.Size = new System.Drawing.Size(285, 139);
            this.treeConnection.TabIndex = 0;
            this.treeConnection.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConnection_AfterSelect);
            this.treeConnection.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeConnection_NodeMouseClick);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "Collapse.png");
            this.imageList2.Images.SetKeyName(10, "Connection_Add.png");
            this.imageList2.Images.SetKeyName(11, "Copy.png");
            this.imageList2.Images.SetKeyName(12, "Delete.png");
            this.imageList2.Images.SetKeyName(13, "Expand.png");
            this.imageList2.Images.SetKeyName(14, "Folder.ico.png");
            this.imageList2.Images.SetKeyName(15, "Folder_Add.png");
            this.imageList2.Images.SetKeyName(16, "HostStatus_Check.png");
            this.imageList2.Images.SetKeyName(17, "HostStatus_Off.png");
            this.imageList2.Images.SetKeyName(18, "HostStatus_On.png");
            this.imageList2.Images.SetKeyName(19, "Play.png");
            this.imageList2.Images.SetKeyName(20, "Refresh.png");
            this.imageList2.Images.SetKeyName(21, "Rename.png");
            this.imageList2.Images.SetKeyName(22, "Sort_ZA.png");
            this.imageList2.Images.SetKeyName(23, "Root_Icon.ico");
            this.imageList2.Images.SetKeyName(24, "View.png");
            this.imageList2.Images.SetKeyName(25, "redo.png");
            this.imageList2.Images.SetKeyName(26, "undo.png");
            // 
            // bar1
            // 
            this.bar1.AccessibleDescription = "Connection Commands (bar1)";
            this.bar1.AccessibleName = "Connection Commands";
            this.bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.DockTabStripHeight = 20;
            this.bar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bar1.Images = this.imageList2;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAddNewConnect,
            this.btnAddNewFolder,
            this.item_299});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Margin = new System.Windows.Forms.Padding(0);
            this.bar1.Name = "bar1";
            this.bar1.PaddingBottom = 4;
            this.bar1.PaddingTop = 3;
            this.bar1.Size = new System.Drawing.Size(285, 28);
            this.bar1.Stretch = true;
            this.bar1.TabIndex = 13;
            this.bar1.TabStop = false;
            this.bar1.Text = "Connection Commands";
            // 
            // btnAddNewConnect
            // 
            this.btnAddNewConnect.GlobalName = "item_61";
            this.btnAddNewConnect.ImageIndex = 10;
            this.btnAddNewConnect.ImagePaddingHorizontal = 10;
            this.btnAddNewConnect.ImagePaddingVertical = 5;
            this.btnAddNewConnect.Name = "btnAddNewConnect";
            this.btnAddNewConnect.Text = "&NewConnection";
            this.btnAddNewConnect.Tooltip = "New Connection";
            this.btnAddNewConnect.Click += new System.EventHandler(this.btnAddNewConnect_Click);
            // 
            // btnAddNewFolder
            // 
            this.btnAddNewFolder.BeginGroup = true;
            this.btnAddNewFolder.GlobalName = "item_239";
            this.btnAddNewFolder.ImageIndex = 15;
            this.btnAddNewFolder.ImagePaddingHorizontal = 10;
            this.btnAddNewFolder.ImagePaddingVertical = 5;
            this.btnAddNewFolder.Name = "btnAddNewFolder";
            this.btnAddNewFolder.Tooltip = "New Folder";
            this.btnAddNewFolder.Click += new System.EventHandler(this.btnAddNewFolder_Click);
            // 
            // item_299
            // 
            this.item_299.BeginGroup = true;
            this.item_299.GlobalName = "item_299";
            this.item_299.ImageIndex = 24;
            this.item_299.ImagePaddingHorizontal = 1;
            this.item_299.ImagePaddingVertical = 5;
            this.item_299.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.item_299.Name = "item_299";
            this.item_299.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnExpandFolder,
            this.btnCollapseFolder});
            this.item_299.Text = "x";
            this.item_299.Tooltip = "Collapse All";
            // 
            // btnExpandFolder
            // 
            this.btnExpandFolder.Name = "btnExpandFolder";
            this.btnExpandFolder.Text = "Expand all folders";
            this.btnExpandFolder.Click += new System.EventHandler(this.btnExpandFolder_Click);
            // 
            // btnCollapseFolder
            // 
            this.btnCollapseFolder.Name = "btnCollapseFolder";
            this.btnCollapseFolder.Text = "Collapse all folders";
            this.btnCollapseFolder.Click += new System.EventHandler(this.btnCollapseFolder_Click);
            // 
            // dConnections
            // 
            this.dConnections.Control = this.panelDockContainer3;
            this.dConnections.GlobalItem = true;
            this.dConnections.GlobalName = "dConnections";
            this.dConnections.ImageIndex = 0;
            this.dConnections.Name = "dConnections";
            this.dConnections.Text = "Connections";
            // 
            // barProperty
            // 
            this.barProperty.AccessibleDescription = "DotNetBar Bar (barProperty)";
            this.barProperty.AccessibleName = "DotNetBar Bar";
            this.barProperty.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.barProperty.AutoHideAnimationTime = 0;
            this.barProperty.AutoSyncBarCaption = true;
            this.barProperty.CanDockTop = false;
            this.barProperty.CanHide = true;
            this.barProperty.CloseSingleTab = true;
            this.barProperty.Controls.Add(this.panelDockContainer4);
            this.barProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barProperty.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.Caption;
            this.barProperty.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.dSolutionProperties});
            this.barProperty.LayoutType = DevComponents.DotNetBar.eLayoutType.DockContainer;
            this.barProperty.Location = new System.Drawing.Point(0, 196);
            this.barProperty.Name = "barProperty";
            this.barProperty.Size = new System.Drawing.Size(291, 240);
            this.barProperty.Stretch = true;
            this.barProperty.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.barProperty.TabIndex = 1;
            this.barProperty.TabStop = false;
            this.barProperty.Text = "Properties";
            // 
            // panelDockContainer4
            // 
            this.panelDockContainer4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.panelDockContainer4.Controls.Add(this.propertyGrid1);
            this.panelDockContainer4.Location = new System.Drawing.Point(3, 23);
            this.panelDockContainer4.Name = "panelDockContainer4";
            this.panelDockContainer4.Size = new System.Drawing.Size(285, 214);
            this.panelDockContainer4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelDockContainer4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelDockContainer4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelDockContainer4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelDockContainer4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelDockContainer4.Style.GradientAngle = 90;
            this.panelDockContainer4.TabIndex = 2;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGrid1.Size = new System.Drawing.Size(285, 214);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // dSolutionProperties
            // 
            this.dSolutionProperties.Control = this.panelDockContainer4;
            this.dSolutionProperties.GlobalItem = true;
            this.dSolutionProperties.GlobalName = "dSolutionProperties";
            this.dSolutionProperties.ImageIndex = 1;
            this.dSolutionProperties.Name = "dSolutionProperties";
            this.dSolutionProperties.Text = "Properties";
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(939, 50);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 436);
            this.barRightDockSite.TabIndex = 2;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite5.Location = new System.Drawing.Point(0, 584);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(939, 0);
            this.dockSite5.TabIndex = 11;
            this.dockSite5.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite2.Location = new System.Drawing.Point(0, 50);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 534);
            this.dockSite2.TabIndex = 8;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite3.Location = new System.Drawing.Point(939, 50);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(0, 534);
            this.dockSite3.TabIndex = 9;
            this.dockSite3.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Controls.Add(this.barMenu);
            this.dockSite4.Controls.Add(this.mainmenu);
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite4.Location = new System.Drawing.Point(0, 0);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(939, 50);
            this.dockSite4.TabIndex = 10;
            this.dockSite4.TabStop = false;
            // 
            // barMenu
            // 
            this.barMenu.AccessibleDescription = "DotNetBar Bar (barMenu)";
            this.barMenu.AccessibleName = "DotNetBar Bar";
            this.barMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.barMenu.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.barMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem2,
            this.buttonItem3,
            this.buttonItem4});
            this.barMenu.Location = new System.Drawing.Point(0, 0);
            this.barMenu.MenuBar = true;
            this.barMenu.Name = "barMenu";
            this.barMenu.Size = new System.Drawing.Size(939, 24);
            this.barMenu.Stretch = true;
            this.barMenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.barMenu.TabIndex = 1;
            this.barMenu.TabStop = false;
            this.barMenu.Text = "bar2";
            this.barMenu.ItemClick += new System.EventHandler(this.bar2_ItemClick);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNewConnectionMenu,
            this.btnNewFolderMenu,
            this.btnDeleteConnection,
            this.btnRenameConnection,
            this.btnDupplicateConnection});
            this.buttonItem1.Text = "File";
            // 
            // btnNewConnectionMenu
            // 
            this.btnNewConnectionMenu.Image = global::SqlCompare.Properties.Resources.Connection_Add;
            this.btnNewConnectionMenu.Name = "btnNewConnectionMenu";
            this.btnNewConnectionMenu.Text = "New Connection";
            // 
            // btnNewFolderMenu
            // 
            this.btnNewFolderMenu.Image = global::SqlCompare.Properties.Resources.Folder_Add;
            this.btnNewFolderMenu.Name = "btnNewFolderMenu";
            this.btnNewFolderMenu.Text = "New Folder";
            // 
            // btnDeleteConnection
            // 
            this.btnDeleteConnection.Image = global::SqlCompare.Properties.Resources.Delete;
            this.btnDeleteConnection.Name = "btnDeleteConnection";
            this.btnDeleteConnection.Text = "Delete Connection...";
            // 
            // btnRenameConnection
            // 
            this.btnRenameConnection.Image = global::SqlCompare.Properties.Resources.Rename;
            this.btnRenameConnection.Name = "btnRenameConnection";
            this.btnRenameConnection.Text = "Rename Connection";
            // 
            // btnDupplicateConnection
            // 
            this.btnDupplicateConnection.Image = global::SqlCompare.Properties.Resources.Copy;
            this.btnDupplicateConnection.Name = "btnDupplicateConnection";
            this.btnDupplicateConnection.Text = "Dupplicate Connection";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnConnections,
            this.btnConfig});
            this.buttonItem2.Text = "View";
            // 
            // btnConnections
            // 
            this.btnConnections.Name = "btnConnections";
            this.btnConnections.Text = "Connections";
            // 
            // btnConfig
            // 
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Text = "Config";
            // 
            // buttonItem3
            // 
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAppendString,
            this.btnGenerateSql});
            this.buttonItem3.Text = "Tools";
            // 
            // btnAppendString
            // 
            this.btnAppendString.Name = "btnAppendString";
            this.btnAppendString.Text = "Append String";
            // 
            // btnGenerateSql
            // 
            this.btnGenerateSql.Name = "btnGenerateSql";
            this.btnGenerateSql.Text = "Generate Sql";
            this.btnGenerateSql.Click += new System.EventHandler(this.btnGenerateSql_Click);
            // 
            // buttonItem4
            // 
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAbout});
            this.buttonItem4.Text = "Help";
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Text = "About";
            // 
            // mainmenu
            // 
            this.mainmenu.AccessibleDescription = "DotNetBar Bar (mainmenu)";
            this.mainmenu.AccessibleName = "DotNetBar Bar";
            this.mainmenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.mainmenu.Controls.Add(this.tsMain);
            this.mainmenu.DockLine = 1;
            this.mainmenu.DockSide = DevComponents.DotNetBar.eDockSide.Top;
            this.mainmenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mainmenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.item_67,
            this.item_167});
            this.mainmenu.Location = new System.Drawing.Point(0, 25);
            this.mainmenu.LockDockPosition = true;
            this.mainmenu.MenuBar = true;
            this.mainmenu.Name = "mainmenu";
            this.mainmenu.Size = new System.Drawing.Size(939, 24);
            this.mainmenu.Stretch = true;
            this.mainmenu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.mainmenu.TabIndex = 0;
            this.mainmenu.TabStop = false;
            this.mainmenu.Text = "Main Menu";
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.btInvisibleChars,
            this.btHighlightCurrentLine,
            this.btShowFoldingLines,
            this.toolStripSeparator4,
            this.undoStripButton,
            this.redoStripButton,
            this.toolStripSeparator5,
            this.backStripButton,
            this.forwardStripButton,
            this.tbFind,
            this.toolStripLabel1,
            this.toolStripSeparator6,
            this.bookmarkPlusButton,
            this.bookmarkMinusButton,
            this.gotoButton});
            this.tsMain.Location = new System.Drawing.Point(0, -3);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(939, 27);
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.pasteToolStripButton.Text = "&Paste";
            // 
            // btInvisibleChars
            // 
            this.btInvisibleChars.CheckOnClick = true;
            this.btInvisibleChars.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btInvisibleChars.Image = ((System.Drawing.Image)(resources.GetObject("btInvisibleChars.Image")));
            this.btInvisibleChars.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btInvisibleChars.Name = "btInvisibleChars";
            this.btInvisibleChars.Size = new System.Drawing.Size(23, 24);
            this.btInvisibleChars.ToolTipText = "Show invisible chars";
            // 
            // btHighlightCurrentLine
            // 
            this.btHighlightCurrentLine.CheckOnClick = true;
            this.btHighlightCurrentLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btHighlightCurrentLine.Image = global::SqlCompare.Properties.Resources.edit_padding_top;
            this.btHighlightCurrentLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btHighlightCurrentLine.Name = "btHighlightCurrentLine";
            this.btHighlightCurrentLine.Size = new System.Drawing.Size(24, 24);
            this.btHighlightCurrentLine.Text = "Highlight current line";
            this.btHighlightCurrentLine.ToolTipText = "Highlight current line";
            // 
            // btShowFoldingLines
            // 
            this.btShowFoldingLines.Checked = true;
            this.btShowFoldingLines.CheckOnClick = true;
            this.btShowFoldingLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btShowFoldingLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btShowFoldingLines.Image = ((System.Drawing.Image)(resources.GetObject("btShowFoldingLines.Image")));
            this.btShowFoldingLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btShowFoldingLines.Name = "btShowFoldingLines";
            this.btShowFoldingLines.Size = new System.Drawing.Size(24, 24);
            this.btShowFoldingLines.Text = "Show folding lines";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Image = global::SqlCompare.Properties.Resources.undo_16x16;
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(24, 24);
            this.undoStripButton.Text = "Undo (Ctrl+Z)";
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = global::SqlCompare.Properties.Resources.redo_16x16;
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(24, 24);
            this.redoStripButton.Text = "Redo (Ctrl+R)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // backStripButton
            // 
            this.backStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.backStripButton.Image = global::SqlCompare.Properties.Resources.backward0_16x16;
            this.backStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backStripButton.Name = "backStripButton";
            this.backStripButton.Size = new System.Drawing.Size(24, 24);
            this.backStripButton.Text = "Navigate Backward (Ctrl+ -)";
            // 
            // forwardStripButton
            // 
            this.forwardStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardStripButton.Image = global::SqlCompare.Properties.Resources.forward_16x16;
            this.forwardStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardStripButton.Name = "forwardStripButton";
            this.forwardStripButton.Size = new System.Drawing.Size(24, 24);
            this.forwardStripButton.Text = "Navigate Forward (Ctrl+Shift+ -)";
            // 
            // tbFind
            // 
            this.tbFind.AcceptsReturn = true;
            this.tbFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 24);
            this.toolStripLabel1.Text = "Find: ";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // bookmarkPlusButton
            // 
            this.bookmarkPlusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bookmarkPlusButton.Image = global::SqlCompare.Properties.Resources.layer__plus;
            this.bookmarkPlusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bookmarkPlusButton.Name = "bookmarkPlusButton";
            this.bookmarkPlusButton.Size = new System.Drawing.Size(24, 24);
            this.bookmarkPlusButton.Text = "Add bookmark (Ctrl-B)";
            // 
            // bookmarkMinusButton
            // 
            this.bookmarkMinusButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bookmarkMinusButton.Image = global::SqlCompare.Properties.Resources.layer__minus;
            this.bookmarkMinusButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bookmarkMinusButton.Name = "bookmarkMinusButton";
            this.bookmarkMinusButton.Size = new System.Drawing.Size(24, 24);
            this.bookmarkMinusButton.Text = "Remove bookmark (Ctrl-Shift-B)";
            // 
            // gotoButton
            // 
            this.gotoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gotoButton.Image = ((System.Drawing.Image)(resources.GetObject("gotoButton.Image")));
            this.gotoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gotoButton.Name = "gotoButton";
            this.gotoButton.Size = new System.Drawing.Size(55, 24);
            this.gotoButton.Text = "Goto...";
            // 
            // item_67
            // 
            this.item_67.GlobalName = "item_67";
            this.item_67.Name = "item_67";
            this.item_67.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.item_78,
            this.item_89,
            this.item_100,
            this.item_111,
            this.item_122,
            this.item_133,
            this.item_144,
            this.item_155,
            this.item_166});
            this.item_67.Text = "&File";
            // 
            // item_78
            // 
            this.item_78.GlobalName = "item_78";
            this.item_78.Name = "item_78";
            this.item_78.Text = "&New";
            // 
            // item_89
            // 
            this.item_89.GlobalName = "item_89";
            this.item_89.ImageIndex = 10;
            this.item_89.Name = "item_89";
            this.item_89.Text = "&Open";
            // 
            // item_100
            // 
            this.item_100.GlobalName = "item_100";
            this.item_100.Name = "item_100";
            this.item_100.Text = "&Close";
            // 
            // item_111
            // 
            this.item_111.BeginGroup = true;
            this.item_111.GlobalName = "item_111";
            this.item_111.Name = "item_111";
            this.item_111.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlShiftA);
            this.item_111.Text = "Add Ne&w Item";
            // 
            // item_122
            // 
            this.item_122.GlobalName = "item_122";
            this.item_122.Name = "item_122";
            this.item_122.Text = "Add Existin&g Item";
            // 
            // item_133
            // 
            this.item_133.GlobalName = "item_133";
            this.item_133.Name = "item_133";
            this.item_133.Text = "A&dd Project";
            // 
            // item_144
            // 
            this.item_144.BeginGroup = true;
            this.item_144.GlobalName = "item_144";
            this.item_144.Name = "item_144";
            this.item_144.Text = "Open Solution";
            // 
            // item_155
            // 
            this.item_155.GlobalName = "item_155";
            this.item_155.Name = "item_155";
            this.item_155.Text = "Close Solution";
            // 
            // item_166
            // 
            this.item_166.BeginGroup = true;
            this.item_166.GlobalName = "item_166";
            this.item_166.Name = "item_166";
            this.item_166.Text = "&Exit";
            // 
            // item_167
            // 
            this.item_167.GlobalName = "item_167";
            this.item_167.Name = "item_167";
            this.item_167.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.item_237,
            this.item_248,
            this.item_259,
            this.item_270,
            this.item_281,
            this.item_292,
            this.item_303});
            this.item_167.Text = "&Edit";
            // 
            // item_237
            // 
            this.item_237.GlobalName = "item_237";
            this.item_237.Name = "item_237";
            this.item_237.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ);
            this.item_237.Text = "&Undo";
            // 
            // item_248
            // 
            this.item_248.GlobalName = "item_248";
            this.item_248.Name = "item_248";
            this.item_248.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY);
            this.item_248.Text = "&Redo";
            // 
            // item_259
            // 
            this.item_259.BeginGroup = true;
            this.item_259.GlobalName = "item_259";
            this.item_259.ImageIndex = 5;
            this.item_259.Name = "item_259";
            this.item_259.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX);
            this.item_259.Text = "Cut";
            // 
            // item_270
            // 
            this.item_270.GlobalName = "item_270";
            this.item_270.ImageIndex = 4;
            this.item_270.Name = "item_270";
            this.item_270.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC);
            this.item_270.Text = "Copy";
            // 
            // item_281
            // 
            this.item_281.GlobalName = "item_281";
            this.item_281.ImageIndex = 11;
            this.item_281.Name = "item_281";
            this.item_281.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV);
            this.item_281.Text = "Paste";
            // 
            // item_292
            // 
            this.item_292.GlobalName = "item_292";
            this.item_292.Name = "item_292";
            this.item_292.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.Del);
            this.item_292.Text = "Delete";
            // 
            // item_303
            // 
            this.item_303.GlobalName = "item_303";
            this.item_303.Name = "item_303";
            this.item_303.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA);
            this.item_303.Text = "Select All";
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 50);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(939, 0);
            this.barTopDockSite.TabIndex = 3;
            this.barTopDockSite.TabStop = false;
            // 
            // buttonChangeStyle
            // 
            this.buttonChangeStyle.AutoExpandOnClick = true;
            this.buttonChangeStyle.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonChangeStyle.Name = "buttonChangeStyle";
            this.buttonChangeStyle.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonStyleMetro,
            this.buttonStyleOffice2010Blue,
            this.buttonStyleOffice2010Silver,
            this.buttonStyleOffice2010Black,
            this.buttonStyleVS2010,
            this.buttonItem62,
            this.buttonStyleOffice2007Blue,
            this.buttonStyleOffice2007Black,
            this.buttonStyleOffice2007Silver,
            this.buttonItem60,
            this.buttonStyleCustom});
            this.buttonChangeStyle.Text = "Style";
            // 
            // buttonStyleMetro
            // 
            this.buttonStyleMetro.Checked = true;
            this.buttonStyleMetro.CommandParameter = "Metro";
            this.buttonStyleMetro.Name = "buttonStyleMetro";
            this.buttonStyleMetro.OptionGroup = "style";
            this.buttonStyleMetro.Text = "Metro/Office 2013";
            // 
            // buttonStyleOffice2010Blue
            // 
            this.buttonStyleOffice2010Blue.CommandParameter = "Office2010Blue";
            this.buttonStyleOffice2010Blue.Name = "buttonStyleOffice2010Blue";
            this.buttonStyleOffice2010Blue.OptionGroup = "style";
            this.buttonStyleOffice2010Blue.Text = "Office 2010 Blue";
            // 
            // buttonStyleOffice2010Silver
            // 
            this.buttonStyleOffice2010Silver.CommandParameter = "Office2010Silver";
            this.buttonStyleOffice2010Silver.Name = "buttonStyleOffice2010Silver";
            this.buttonStyleOffice2010Silver.OptionGroup = "style";
            this.buttonStyleOffice2010Silver.Text = "Office 2010 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonStyleOffice2010Black
            // 
            this.buttonStyleOffice2010Black.CommandParameter = "Office2010Black";
            this.buttonStyleOffice2010Black.Name = "buttonStyleOffice2010Black";
            this.buttonStyleOffice2010Black.OptionGroup = "style";
            this.buttonStyleOffice2010Black.Text = "Office 2010 Black";
            // 
            // buttonStyleVS2010
            // 
            this.buttonStyleVS2010.CommandParameter = "VisualStudio2010Blue";
            this.buttonStyleVS2010.Name = "buttonStyleVS2010";
            this.buttonStyleVS2010.OptionGroup = "style";
            this.buttonStyleVS2010.Text = "Visual Studio 2010";
            // 
            // buttonItem62
            // 
            this.buttonItem62.CommandParameter = "Windows7Blue";
            this.buttonItem62.Name = "buttonItem62";
            this.buttonItem62.OptionGroup = "style";
            this.buttonItem62.Text = "Windows 7";
            // 
            // buttonStyleOffice2007Blue
            // 
            this.buttonStyleOffice2007Blue.CommandParameter = "Office2007Blue";
            this.buttonStyleOffice2007Blue.Name = "buttonStyleOffice2007Blue";
            this.buttonStyleOffice2007Blue.OptionGroup = "style";
            this.buttonStyleOffice2007Blue.Text = "Office 2007 <font color=\"Blue\"><b>Blue</b></font>";
            // 
            // buttonStyleOffice2007Black
            // 
            this.buttonStyleOffice2007Black.CommandParameter = "Office2007Black";
            this.buttonStyleOffice2007Black.Name = "buttonStyleOffice2007Black";
            this.buttonStyleOffice2007Black.OptionGroup = "style";
            this.buttonStyleOffice2007Black.Text = "Office 2007 <font color=\"black\"><b>Black</b></font>";
            // 
            // buttonStyleOffice2007Silver
            // 
            this.buttonStyleOffice2007Silver.CommandParameter = "Office2007Silver";
            this.buttonStyleOffice2007Silver.Name = "buttonStyleOffice2007Silver";
            this.buttonStyleOffice2007Silver.OptionGroup = "style";
            this.buttonStyleOffice2007Silver.Text = "Office 2007 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // buttonItem60
            // 
            this.buttonItem60.CommandParameter = "Office2007VistaGlass";
            this.buttonItem60.Name = "buttonItem60";
            this.buttonItem60.OptionGroup = "style";
            this.buttonItem60.Text = "Vista Glass";
            // 
            // buttonStyleCustom
            // 
            this.buttonStyleCustom.BeginGroup = true;
            this.buttonStyleCustom.Name = "buttonStyleCustom";
            this.buttonStyleCustom.Text = "Custom scheme";
            this.buttonStyleCustom.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" +
    "ting Silver or Blue color table and then creating custom color scheme.";
            // 
            // contextConnection
            // 
            this.contextConnection.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDisconnect,
            this.btnConnect,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnSelectLeftConnection,
            this.btnCompare,
            this.btnDupplicate,
            this.btnRename,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnNewConnection,
            this.btnNewFolder});
            this.contextConnection.Name = "contextConnection";
            this.contextConnection.Size = new System.Drawing.Size(205, 276);
            this.contextConnection.Text = "Connect";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Image = global::SqlCompare.Properties.Resources.HostStatus_Check;
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(204, 26);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Image = global::SqlCompare.Properties.Resources.Play;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(204, 26);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::SqlCompare.Properties.Resources.Refresh;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(204, 26);
            this.btnRefresh.Text = "Refresh";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // btnSelectLeftConnection
            // 
            this.btnSelectLeftConnection.Image = global::SqlCompare.Properties.Resources.undo;
            this.btnSelectLeftConnection.Name = "btnSelectLeftConnection";
            this.btnSelectLeftConnection.Size = new System.Drawing.Size(204, 26);
            this.btnSelectLeftConnection.Text = "Select left connection";
            this.btnSelectLeftConnection.Click += new System.EventHandler(this.btnSelectLeftConnection_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Image = global::SqlCompare.Properties.Resources.beyond_compare;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(204, 26);
            this.btnCompare.Text = "Compare to connection";
            this.btnCompare.Click += new System.EventHandler(this.btnLeftToCompare_Click);
            // 
            // btnDupplicate
            // 
            this.btnDupplicate.Image = global::SqlCompare.Properties.Resources.Copy;
            this.btnDupplicate.Name = "btnDupplicate";
            this.btnDupplicate.Size = new System.Drawing.Size(204, 26);
            this.btnDupplicate.Text = "Dupplicate";
            this.btnDupplicate.Click += new System.EventHandler(this.btnDupplicate_Click);
            // 
            // btnRename
            // 
            this.btnRename.Image = global::SqlCompare.Properties.Resources.Rename;
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(204, 26);
            this.btnRename.Text = "Rename";
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SqlCompare.Properties.Resources.Delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(204, 26);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // btnNewConnection
            // 
            this.btnNewConnection.Image = global::SqlCompare.Properties.Resources.Connection_Add;
            this.btnNewConnection.Name = "btnNewConnection";
            this.btnNewConnection.Size = new System.Drawing.Size(204, 26);
            this.btnNewConnection.Text = "New Connection";
            this.btnNewConnection.Click += new System.EventHandler(this.btnNewConnection_Click);
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Image = global::SqlCompare.Properties.Resources.Folder_Add;
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(204, 26);
            this.btnNewFolder.Text = "New Folder";
            this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
            // 
            // tsFiles
            // 
            this.tsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsFiles.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsFiles.Location = new System.Drawing.Point(294, 50);
            this.tsFiles.Name = "tsFiles";
            this.tsFiles.Size = new System.Drawing.Size(645, 436);
            this.tsFiles.TabIndex = 13;
            this.tsFiles.Text = "faTabStrip1";
            this.tsFiles.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.tsFiles_TabStripItemSelectionChanged_1);
            // 
            // cmMain
            // 
            this.cmMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripMenuItem4,
            this.autoIndentSelectedTextToolStripMenuItem,
            this.commentSelectedToolStripMenuItem,
            this.uncommentSelectedToolStripMenuItem,
            this.cloneLinesToolStripMenuItem,
            this.cloneLinesAndCommentToolStripMenuItem});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(223, 360);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.selectAllToolStripMenuItem.Text = "Select all";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(219, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.undo_16x16;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::SqlCompare.Properties.Resources.redo_16x16;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(219, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.replaceToolStripMenuItem.Text = "Replace";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(219, 6);
            // 
            // autoIndentSelectedTextToolStripMenuItem
            // 
            this.autoIndentSelectedTextToolStripMenuItem.Name = "autoIndentSelectedTextToolStripMenuItem";
            this.autoIndentSelectedTextToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.autoIndentSelectedTextToolStripMenuItem.Text = "AutoIndent selected text";
            // 
            // commentSelectedToolStripMenuItem
            // 
            this.commentSelectedToolStripMenuItem.Name = "commentSelectedToolStripMenuItem";
            this.commentSelectedToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.commentSelectedToolStripMenuItem.Text = "Comment selected";
            // 
            // uncommentSelectedToolStripMenuItem
            // 
            this.uncommentSelectedToolStripMenuItem.Name = "uncommentSelectedToolStripMenuItem";
            this.uncommentSelectedToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.uncommentSelectedToolStripMenuItem.Text = "Uncomment selected";
            // 
            // cloneLinesToolStripMenuItem
            // 
            this.cloneLinesToolStripMenuItem.Name = "cloneLinesToolStripMenuItem";
            this.cloneLinesToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.cloneLinesToolStripMenuItem.Text = "Clone line(s)";
            // 
            // cloneLinesAndCommentToolStripMenuItem
            // 
            this.cloneLinesAndCommentToolStripMenuItem.Name = "cloneLinesAndCommentToolStripMenuItem";
            this.cloneLinesAndCommentToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.cloneLinesAndCommentToolStripMenuItem.Text = "Clone line(s) and comment";
            // 
            // listImagecon
            // 
            this.listImagecon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listImagecon.ImageStream")));
            this.listImagecon.TransparentColor = System.Drawing.Color.Transparent;
            this.listImagecon.Images.SetKeyName(0, "script_16x16.png");
            this.listImagecon.Images.SetKeyName(1, "app_16x16.png");
            this.listImagecon.Images.SetKeyName(2, "1302166543_virtualbox.png");
            // 
            // ofdMain
            // 
            this.ofdMain.DefaultExt = "cs";
            this.ofdMain.Filter = "C# file(*.cs)|*.cs";
            // 
            // sfdMain
            // 
            this.sfdMain.DefaultExt = "cs";
            this.sfdMain.Filter = "C# file(*.cs)|*.cs";
            // 
            // FrmSupportSql
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 584);
            this.Controls.Add(this.tsFiles);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite5);
            this.IsMdiContainer = true;
            this.Name = "FrmSupportSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.barBottomDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barResult)).EndInit();
            this.barResult.ResumeLayout(false);
            this.panelDockContainerResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSyncResult)).EndInit();
            this.barLeftDockSite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barConnections)).EndInit();
            this.barConnections.ResumeLayout(false);
            this.panelDockContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barProperty)).EndInit();
            this.barProperty.ResumeLayout(false);
            this.panelDockContainer4.ResumeLayout(false);
            this.dockSite4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainmenu)).EndInit();
            this.mainmenu.ResumeLayout(false);
            this.mainmenu.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.contextConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsFiles)).EndInit();
            this.cmMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void Form1_Load(object sender, System.EventArgs e)
        {
            waitForm.Show();
            try
            {
                // Create inital document bar
                Bar bar = BarUtilities.CreateDocumentBar();
                bar.Name = "barDocuments";
                bar.DockTabClosing += new DockTabClosingEventHandler(DocumentBar_DockTabClosing);
                //dockSite1.GetDocumentUIManager().Dock(bar);
                //CreateNewDocument();
                //createProp();

                initTreeConnection();
                //treeConnection.AfterSelect += new TreeViewEventHandler(treeConnection_AfterSelect);
            }
            catch { }
            finally
            {
                waitForm.Close();
            }

        }

        public void initTreeConnection()
        {
            var file = "./Data/Backup/treeConnection1.cofig";
            if (File.Exists(file))
            {
                Data.LoadTree(treeConnection, new FileInfo(file).FullName);
            }
            else
            {
                TreeNodeConnection treeNode1 = new TreeNodeConnection("New Connection", Constant.Img_NewConnection, Constant.Img_NewConnection);
                TreeNodeConnection treeNode2 = new TreeNodeConnection("New Connection", Constant.Img_NewConnection, Constant.Img_NewConnection);
                TreeNodeConnection treeNode3 = new TreeNodeConnection("New Connection", Constant.Img_NewConnection, Constant.Img_NewConnection);
                TreeNodeConnection treeNode4 = new TreeNodeConnection("New Folder", Constant.Img_NewFolder, Constant.Img_NewFolder, new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
                TreeNodeConnection treeNode5 = new TreeNodeConnection("Connections", Constant.Img_Connection, Constant.Img_Connection, new System.Windows.Forms.TreeNode[] {
            treeNode4});

                this.treeConnection.Nodes.AddRange(new TreeNode[] { treeNode5 });
            }

            this.treeConnection.SelectedImageIndex = 7;
            this.treeConnection.Size = new System.Drawing.Size(214, 113);
            this.treeConnection.TabIndex = 12;

            this.treeConnection.NodeMouseClick += treeConnection_NodeMouseClick;
            this.treeConnection.KeyDown += treeConnection_KeyDown;

            treeConnection.AllowDrop = true;
            // Add event handlers for the required drag events.  
            treeConnection.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            treeConnection.DragEnter += new DragEventHandler(treeView1_DragEnter);
            treeConnection.DragOver += new DragEventHandler(treeView1_DragOver);
            treeConnection.DragDrop += new DragEventHandler(treeView1_DragDrop);
            treeConnection.AfterLabelEdit += treeNode_AfterLabelEdit;
            treeConnection.ExpandAll();

            //propertyGrid1.SelectedObject = 

            //propertyGrid1.HiddenProperties = new string[] { "DataBinidngs" };
        }

        private void treeConnection_KeyDown(object sender, KeyEventArgs e)
        {
            if (treeConnection.SelectedNode != null)
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (treeConnection.SelectedNode.ImageIndex != Constant.Img_Connection)
                        {
                            treeConnection.LabelEdit = true;
                            treeConnection.SelectedNode.BeginEdit();
                        }
                        break;
                    case Keys.F2:
                        if (treeConnection.SelectedNode.ImageIndex != Constant.Img_Connection)
                        {
                            treeConnection.LabelEdit = true;
                            treeConnection.SelectedNode.BeginEdit();
                        }
                        break;
                    case Keys.Space:
                        treeConnection.SelectedNode.Toggle();
                        break;
                    default:
                        break;
                }
        }

        void treeConnection_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeConnection.SelectedNode = e.Node;
            }

            btnSelectLeftConnection.Visible = false;
            btnCompare.Visible = false;

            if (treeConnection.SelectedNode.ImageIndex == Constant.Img_Connection)
            {
                btnDelete.Visible = false;
                btnDupplicate.Visible = false;
                btnRename.Visible = false;
            }
            else
            {
                btnRename.Visible = true;
                btnDelete.Visible = true;
                btnDupplicate.Visible = true;
            }

            if (treeConnection.SelectedNode.ImageIndex == Constant.Img_ConnectionSuccess)
            {
                btnRefresh.Visible = true;
                btnDisconnect.Visible = true;
                btnSelectLeftConnection.Visible = NodeA != (TreeNodeConnection)treeConnection.SelectedNode;
                btnCompare.Visible = NodeA != null && NodeA != (TreeNodeConnection)treeConnection.SelectedNode;
            }
            else
            {
                btnRefresh.Visible = false;
                btnDisconnect.Visible = false;
            }

            btnConnect.Visible = false;
            if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewConnection)
            {
                if (!string.IsNullOrEmpty(((TreeNodeConnection)treeConnection.SelectedNode).Connection))
                {
                    btnConnect.Visible = true;
                    btnConnect.Enabled = true;
                    btnSelectLeftConnection.Visible = NodeA != (TreeNodeConnection)treeConnection.SelectedNode;
                    btnCompare.Visible = NodeA != null && NodeA != (TreeNodeConnection)treeConnection.SelectedNode;
                }
            }

            e.Node.ContextMenuStrip = contextConnection;
            //if (e.Node.Level == 0)
        }

        private void treeConnection_AfterSelect(object sender, TreeViewEventArgs e)
        {
            propertyGrid1.SelectedObject = treeConnection.SelectedNode;
        }

        private void CreateNewDocument()
        {
            // Create new DockContainerItem with the edit control and add it to the barDocuments
            m_DocumentCount++;
            DockContainerItem document = new DockContainerItem("docDock" + m_DocumentCount, "Document [" + m_DocumentCount + "]");
            // Create control to host inside of new document
            document.Control = CreateNewDocumentControl();
            Bar bar = GetFirstDocumentBar();
            bar.Items.Add(document);
            if (!bar.Visible)
                bar.Visible = true;
            bar.SelectedDockTab = bar.Items.IndexOf(document);
            bar.RecalcLayout();
        }

        private Bar GetFirstDocumentBar()
        {
            foreach (Bar b in dotNetBarManager1.Bars)
            {
                if (b.DockSide == eDockSide.Document && b.Visible)
                    return b;
            }

            // If no documents bars found, create new one
            m_UniqueBarCount++;
            Bar bar = BarUtilities.CreateDocumentBar();
            bar.DockTabClosing += new DockTabClosingEventHandler(DocumentBar_DockTabClosing);
            bar.Name = "barDocuments" + m_UniqueBarCount.ToString();
            //dockSite1.GetDocumentUIManager().Dock(bar);

            return bar;
        }

        private Control CreateNewDocumentControl()
        {
            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.ScrollBars = ScrollBars.Vertical;
            txt.AutoSize = false;
            return txt;
        }

        private void DocumentBar_DockTabClosing(object sender, DevComponents.DotNetBar.DockTabClosingEventArgs e)
        {
            // In this event you save any changes to the active document or cancel the closing...
            // e.DockContainerItem returns the reference to the item being closed
            // Set e.Cancel to true to cancel the closing
            // Set e.RemoveDockTab to true to automatically remove the closed tab from Bar.Items collection
            e.RemoveDockTab = true;

            if (((Bar)sender).Items.Count == 1) // Remove bar if last item is closed...
                dotNetBarManager1.Bars.Remove((Bar)sender);
        }

        private void dotNetBarManager1_BarTearOff(object sender, System.EventArgs e)
        {
            Bar b = sender as Bar;
            b.DockTabClosing += new DockTabClosingEventHandler(DocumentBar_DockTabClosing);
        }

        private void dotNetBarManager1_ItemClick(object sender, System.EventArgs e)
        {
            BaseItem item = sender as BaseItem;
            if (item == null) return;

            if (item.Name == "buttonNew")
            {
                CreateNewDocument();
            }
        }

        private void btnAddNewConnect_Click(object sender, EventArgs e)
        {
            AddNewConnection();
        }

        public void AddNewConnection()
        {
            if (treeConnection.SelectedNode != null)
            {
                //MessageBox.Show(treeConnection.SelectedNode.ImageIndex.ToString());
                TreeNodeConnection treeNode = new TreeNodeConnection("New Connection", Constant.Img_NewConnection, Constant.Img_NewConnection);
                if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewFolder || treeConnection.SelectedNode.ImageIndex == Constant.Img_Connection)
                {
                    treeConnection.SelectedNode.Nodes.Add(treeNode);
                }
                else if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewConnection)
                {
                    treeConnection.SelectedNode.Parent.Nodes.Add(treeNode);
                }

                treeConnection.SelectedNode = treeNode;
                //treeNode.LastNode= True
                treeConnection.LabelEdit = true;

                treeConnection.SelectedNode.BeginEdit();

                //propertyGrid1.SelectedObject = treeNode;

                //setPropertyOfDatabase();

                //treeNode.GetType().GetProperty("ImageIndex").Attributes.;
                //TypeDescriptor.GetAttributes(treeNode)[]
                //TypeDescriptor.AddAttributes(treeNode, new Attribute[] { new ReadOnlyAttribute(true) });
                //propertyGrid1.SelectedObject = treeNode;

                //PropertyDescriptor pd = TypeDescriptor.GetProperties(treeNode)["ImageIndex"];
                //var att = pd.Attributes[typeof(DescriptionAttribute)] as DescriptionAttribute;

                //if (att != null)
                //{
                //    var fieldDescription = att.GetType().GetField("Browsable");
                //    if (fieldDescription != null)
                //    {
                //        fieldDescription.SetValue(att, false);
                //    }
                //}

                //TypeDescriptor.AddAttributes(pd, new Attribute[] { new ReadOnlyAttribute(true) });


                //var prop = treeNode.GetType().GetProperty("ImageIndex");
                //prop.Attributes.GetType()
                //AttributeCollection runtimeAttributes = prop.Attributes;
                //// make a copy of the original attributes
                //// but make room for one extra attribute
                //Attribute[] attrs = new Attribute[runtimeAttributes.Count + 1];
                //runtimeAttributes.CopyTo(attrs, 0);
                //attrs[runtimeAttributes.Count] = new BrowsableAttribute(false);

                //// makes this Property hidden in PropertyGrid
                //prop = TypeDescriptor.CreateProperty(this.GetType(), propname, prop.PropertyType, attrs);
                //properties[propname] = prop;

                //AttributeCollection attributes = TypeDescriptor.GetProperties(treeNode)["ImageIndex"].Attributes;

                ////trying to add ResultPropertyAttribute to my property
                //var prop = TypeDescriptor.GetProperties(treeNode)["ImageIndex"];
                //prop.
                ////prop.Attributes
                //TypeDescriptor.AddAttributes(treeNode, new BrowsableAttribute(false));

                ////querying again to check if the ResultPropertyAttribute has been added but => I don't see them being added

                //attributes = TypeDescriptor.GetProperties(treeNode)["ImageIndex"].Attributes;

                propertyGrid1.SelectedObject = treeNode;

                //setBrowsableProperty(TypeDescriptor.GetProperties(treeNode)["ImageIndex"], false);

                //BrowsableAttribute browse = TypeDescriptor.GetProperties(treeNode)["ImageIndex"].Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;
                //System.Reflection.FieldInfo field = browse.GetType().GetField("browsable", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                //field.SetValue(browse, false);

                Data.BackupTree(treeConnection);
            }
        }

        private void setBrowsableProperty(string strPropertyName, bool bIsBrowsable)
        {
            // Get the Descriptor's Properties
            PropertyDescriptor theDescriptor = TypeDescriptor.GetProperties(this.GetType())[strPropertyName];

            // Get the Descriptor's "Browsable" Attribute
            BrowsableAttribute theDescriptorBrowsableAttribute = (BrowsableAttribute)theDescriptor.Attributes[typeof(BrowsableAttribute)];
            FieldInfo isBrowsable = theDescriptorBrowsableAttribute.GetType().GetField("Browsable", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the Descriptor's "Browsable" Attribute
            isBrowsable.SetValue(theDescriptorBrowsableAttribute, bIsBrowsable);
        }

        public void setPropertyOfDatabase()
        {
            Database db = new Database();
            db.Name = treeConnection.SelectedNode.Text;
            propertyGrid1.SelectedObject = db;
        }

        public void AddNewFolder()
        {
            if (treeConnection.SelectedNode != null)
            {
                //MessageBox.Show(treeConnection.SelectedNode.ImageIndex.ToString());
                TreeNodeConnection treeNode = new TreeNodeConnection("New Folder", Constant.Img_NewFolder, Constant.Img_NewFolder);
                if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewFolder || treeConnection.SelectedNode.ImageIndex == Constant.Img_Connection)
                {
                    treeConnection.SelectedNode.Nodes.Add(treeNode);
                }
                else if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewConnection)
                {
                    treeConnection.SelectedNode.Parent.Nodes.Add(treeNode);
                }

                treeConnection.SelectedNode = treeNode;
                propertyGrid1.SelectedObject = treeNode;
                Data.BackupTree(treeConnection);
            }
        }

        private void btnAddNewFolder_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void treeNode_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //treeConnection.LabelEdit = false;
            //MessageBox.Show(e.Label);
            if (!string.IsNullOrEmpty(e.Label))
            {
                treeConnection.SelectedNode.Text = e.Label;
                Data.BackupTree(treeConnection);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewFolder)
            {
                if (treeConnection.SelectedNode.Nodes.Count == 0)
                {
                    message = "Are you sure you want to delete the empty folder " + treeConnection.SelectedNode.Text;
                }
                else
                {
                    message = "Are you sure you want to delete the folder " + treeConnection.SelectedNode.Text + "? Any folders or connections that it contains will also be deleted";
                }
            }
            else if (treeConnection.SelectedNode.ImageIndex == Constant.Img_NewConnection)
            {
                message = "Are you sure you want to delete the connection: " + treeConnection.SelectedNode.Text;
            }

            if (DialogResult.Yes == MessageBox.Show(message, "Support Sql", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                treeConnection.SelectedNode.Remove();
                Data.BackupTree(treeConnection);
            }
        }

        private void btnExpandFolder_Click(object sender, EventArgs e)
        {
            treeConnection.ExpandAll();
        }

        private void btnCollapseFolder_Click(object sender, EventArgs e)
        {
            treeConnection.CollapseAll();
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.  
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        //After this we will create the treeView1_DragEnter event. 
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        //Now we will create the treeView1_DragOver event, 
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = treeConnection.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            treeConnection.SelectedNode = treeConnection.GetNodeAt(targetPoint);
        }

        //Now we will create the treeView1_DragDrop event, 
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.  
            Point targetPoint = treeConnection.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            TreeNode targetNode = treeConnection.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not   
            // the dragged node or a descendant of the dragged node.  
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current   
                // location and add it to the node at the drop location.  
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node   
                // and add it to the node at the drop location.  
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location   
                // to show the dropped node.  
                targetNode.Expand();
            }

        }

        //After that we will use the below function to perform parent child relation, 
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.  
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(node1, node2.Parent);
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Data.BackupTree(treeConnection);
        }

        private void btnDupplicate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Confirm Dupplicate", "Support Sql", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                var obj = (TreeNodeConnection)((TreeNodeConnection)treeConnection.SelectedNode).Clone();
                //var obj = ((TreeNodeConnection)treeConnection.SelectedNode).Clone<TreeNodeConnection>();
                obj.Connection = ((TreeNodeConnection)treeConnection.SelectedNode).Connection;
                setNodeInfo(obj);
                treeConnection.SelectedNode.Parent.Nodes.Add(obj);
                treeConnection.SelectedNode = obj;
                Data.BackupTree(treeConnection);
            }
        }

        public static void setNodeInfo(TreeNodeConnection databaseNode)
        {
            if (databaseNode.ImageIndex == Constant.Img_ConnectionSuccess)
            {
                databaseNode.ImageIndex = Constant.Img_NewConnection;
                databaseNode.SelectedImageIndex = Constant.Img_NewConnection;
            }

            if (databaseNode.Nodes.Count > 0)
            {
                foreach (TreeNodeConnection db in databaseNode.Nodes)
                {
                    setNodeInfo(db);
                }
            }
        }

        private void btnNewConnection_Click(object sender, EventArgs e)
        {
            AddNewConnection();
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            waitForm.Show();
            try
            {
                var listKeyword = string.Join("|", Constant.listSpecial) + "|";

                if (treeConnection.SelectedNode != null)
                {
                    DatabaseInfo db = new DatabaseInfo();
                    db.Connection = ((TreeNodeConnection)treeConnection.SelectedNode).Connection;
                    db.Name = treeConnection.SelectedNode.Text;

                    if (Data.RefreshOnlyDatabase(db))
                    {
                        treeConnection.SelectedNode.ImageIndex = Constant.Img_ConnectionSuccess;
                        treeConnection.SelectedNode.SelectedImageIndex = Constant.Img_ConnectionSuccess;

                        CreateTab(treeConnection.SelectedNode.Text, db);
                    }
                }
            }
            catch { }
            finally
            {
                waitForm.Close();
            }
        }


        #region

        private void dockSite1_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //CreateTab(null);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CreateTab(null);
        }

        private void CreateTab(string fileName, DatabaseInfo db)
        {
            try
            {
                var tb = new FastColoredTextBox();
                tb.Font = new Font("Consolas", 9.75f);
                tb.ContextMenuStrip = cmMain;
                tb.Dock = DockStyle.Fill;
                tb.BorderStyle = BorderStyle.Fixed3D;
                //tb.VirtualSpace = true;
                tb.LeftPadding = 17;
                tb.Language = Language.CSharp;
                tb.AddStyle(sameWordsStyle);//same words style
                var tab = new FATabStripItem(fileName != null ? Path.GetFileName(fileName) : "[new]", tb);
                tab.Tag = fileName;
                //if (fileName != null)
                //    tb.OpenFile(fileName);
                tb.Tag = new TbInfo();
                tsFiles.AddTab(tab);
                tsFiles.SelectedItem = tab;
                tb.Focus();
                //tb.DelayedTextChangedInterval = 0;
                //tb.DelayedEventsInterval = 0;
                //tb.DelayedTextChangedInterval = 1000;
                //tb.DelayedEventsInterval = 500;
                tb.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(tb_TextChangedDelayed);
                tb.SelectionChangedDelayed += new EventHandler(tb_SelectionChangedDelayed);
                tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                tb.MouseMove += new MouseEventHandler(tb_MouseMove);
                tb.ChangedLineColor = changedLineColor;
                if (btHighlightCurrentLine.Checked)
                    tb.CurrentLineColor = currentLineColor;
                tb.ShowFoldingLines = btShowFoldingLines.Checked;
                tb.HighlightingRangeType = HighlightingRangeType.VisibleRange;
                //create autocomplete popup menu
                AutocompleteMenu popupMenu = new AutocompleteMenu(tb);
                popupMenu.Items.ImageList = listImagecon;
                popupMenu.Opening += new EventHandler<CancelEventArgs>(popupMenu_Opening);
                //AutocompleteDropdownConfig.BuildAutocompleteMenu(popupMenu);
                setPopupMenu(popupMenu, db);
                (tb.Tag as TbInfo).popupMenu = popupMenu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Retry)
                //    CreateTab(fileName);
            }
        }

        public static void setPopupMenu(AutocompleteMenu popupMenu, DatabaseInfo db)
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in db.ListTable)
            {
                items.Add(new AutocompleteItem(item.TableName) { ImageIndex = 1 });
            }

            foreach (var item in db.ListFunction)
            {
                items.Add(new AutocompleteItem(item.Name) { ImageIndex = 2 });
            }

            foreach (var item in Constant.listSpecial)
            {
                items.Add(new AutocompleteItem(item.ToString()) { ImageIndex = 2 });
            }

            //set as autocomplete source
            popupMenu.Items.SetAutocompleteItems(items);
            popupMenu.SearchPattern = @"[\w\.:=!<>]";
        }

        void popupMenu_Opening(object sender, CancelEventArgs e)
        {
            //---block autocomplete menu for comments
            //get index of green style (used for comments)
            var iGreenStyle = CurrentTB.GetStyleIndex(CurrentTB.SyntaxHighlighter.GreenStyle);
            if (iGreenStyle >= 0)
                if (CurrentTB.Selection.Start.iChar > 0)
                {
                    //current char (before caret)
                    var c = CurrentTB[CurrentTB.Selection.Start.iLine][CurrentTB.Selection.Start.iChar - 1];
                    //green Style
                    var greenStyleIndex = Range.ToStyleIndex(iGreenStyle);
                    //if char contains green style then block popup menu
                    if ((c.style & greenStyleIndex) != 0)
                        e.Cancel = true;
                }
        }

        void tb_MouseMove(object sender, MouseEventArgs e)
        {
            var tb = sender as FastColoredTextBox;
            var place = tb.PointToPlace(e.Location);
            var r = new Range(tb, place, place);

            string text = r.GetFragment("[a-zA-Z]").Text;
            // lbWordUnderMouse.Text = text;
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.OemMinus)
            {
                NavigateBackward();
                e.Handled = true;
            }

            if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.OemMinus)
            {
                NavigateForward();
                e.Handled = true;
            }

            if (e.KeyData == (Keys.K | Keys.Control))
            {
                //forced show (MinFragmentLength will be ignored)
                (CurrentTB.Tag as TbInfo).popupMenu.Show(true);
                e.Handled = true;
            }
        }

        void tb_SelectionChangedDelayed(object sender, EventArgs e)
        {
            var tb = sender as FastColoredTextBox;
            //remember last visit time
            if (tb.Selection.IsEmpty && tb.Selection.Start.iLine < tb.LinesCount)
            {
                if (lastNavigatedDateTime != tb[tb.Selection.Start.iLine].LastVisit)
                {
                    tb[tb.Selection.Start.iLine].LastVisit = DateTime.Now;
                    lastNavigatedDateTime = tb[tb.Selection.Start.iLine].LastVisit;
                }
            }

            //highlight same words
            tb.VisibleRange.ClearStyle(sameWordsStyle);
            if (!tb.Selection.IsEmpty)
                return;//user selected diapason
            //get fragment around caret
            var fragment = tb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            Range[] ranges = tb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();

            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(sameWordsStyle);
        }

        void tb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            FastColoredTextBox tb = (sender as FastColoredTextBox);
            //show invisible chars
            HighlightInvisibleChars(e.ChangedRange);
        }

        private void HighlightInvisibleChars(Range range)
        {
            range.ClearStyle(invisibleCharsStyle);
            if (btInvisibleChars.Checked)
                range.SetStyle(invisibleCharsStyle, @".$|.\r\n|\s");
        }

        private void tsFiles_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if ((e.Item.Controls[0] as FastColoredTextBox).IsChanged)
            {
                switch (MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        if (!Save(e.Item))
                            e.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private bool Save(FATabStripItem tab)
        {
            var tb = (tab.Controls[0] as FastColoredTextBox);
            if (tab.Tag == null)
            {
                if (sfdMain.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return false;
                tab.Title = Path.GetFileName(sfdMain.FileName);
                tab.Tag = sfdMain.FileName;
            }

            try
            {
                File.WriteAllText(tab.Tag as string, tb.Text);
                tb.IsChanged = false;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    return Save(tab);
                else
                    return false;
            }

            tb.Invalidate();

            return true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tsFiles.SelectedItem != null)
                Save(tsFiles.SelectedItem);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tsFiles.SelectedItem != null)
            {
                string oldFile = tsFiles.SelectedItem.Tag as string;
                tsFiles.SelectedItem.Tag = null;
                if (!Save(tsFiles.SelectedItem))
                    if (oldFile != null)
                    {
                        tsFiles.SelectedItem.Tag = oldFile;
                        tsFiles.SelectedItem.Title = Path.GetFileName(oldFile);
                    }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (ofdMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    CreateTab(ofdMain.FileName);
        }

        FastColoredTextBox CurrentTB
        {
            get
            {
                if (tsFiles.SelectedItem == null)
                    return null;
                return (tsFiles.SelectedItem.Controls[0] as FastColoredTextBox);
            }

            set
            {
                tsFiles.SelectedItem = (value.Parent as FATabStripItem);
                value.Focus();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.Selection.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTB.UndoEnabled)
                CurrentTB.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTB.RedoEnabled)
                CurrentTB.Redo();
        }

        private void tmUpdateInterface_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentTB != null && tsFiles.Items.Count > 0)
                {
                    var tb = CurrentTB;
                    undoStripButton.Enabled = undoToolStripMenuItem.Enabled = tb.UndoEnabled;
                    redoStripButton.Enabled = redoToolStripMenuItem.Enabled = tb.RedoEnabled;
                    saveToolStripButton.Enabled = tb.IsChanged;
                    pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled = true;
                    cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled =
                    copyToolStripButton.Enabled = copyToolStripMenuItem.Enabled = !tb.Selection.IsEmpty;
                    printToolStripButton.Enabled = true;
                }
                else
                {
                    saveToolStripButton.Enabled = false;
                    //  saveAsToolStripMenuItem.Enabled = false;
                    cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled =
                    copyToolStripButton.Enabled = copyToolStripMenuItem.Enabled = false;
                    pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled = false;
                    printToolStripButton.Enabled = false;
                    undoStripButton.Enabled = undoToolStripMenuItem.Enabled = false;
                    redoStripButton.Enabled = redoToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (CurrentTB != null)
            {
                var settings = new PrintDialogSettings();
                settings.Title = tsFiles.SelectedItem.Title;
                settings.Header = "&b&w&b";
                settings.Footer = "&b&p";
                CurrentTB.Print(settings);
            }
        }

        bool tbFindChanged = false;

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && CurrentTB != null)
            {
                Range r = tbFindChanged ? CurrentTB.Range.Clone() : CurrentTB.Selection.Clone();
                tbFindChanged = false;
                r.End = new Place(CurrentTB[CurrentTB.LinesCount - 1].Count, CurrentTB.LinesCount - 1);
                var pattern = Regex.Escape(tbFind.Text);
                foreach (var found in r.GetRanges(pattern))
                {
                    found.Inverse();
                    CurrentTB.Selection = found;
                    CurrentTB.DoSelectionVisible();
                    return;
                }
                MessageBox.Show("Not found.");
            }
            else
                tbFindChanged = true;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.ShowReplaceDialog();
        }

        private void PowerfulCSharpEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<FATabStripItem> list = new List<FATabStripItem>();
            foreach (FATabStripItem tab in tsFiles.Items)
                list.Add(tab);
            foreach (var tab in list)
            {
                TabStripItemClosingEventArgs args = new TabStripItemClosingEventArgs(tab);
                tsFiles_TabStripItemClosing(args);
                if (args.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                tsFiles.RemoveTab(tab);
            }
        }

        private void tsFiles_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            if (CurrentTB != null)
            {
                CurrentTB.Focus();
                string text = CurrentTB.Text;
                //ThreadPool.QueueUserWorkItem(
                //    (o) => ReBuildObjectExplorer(text)
                //);
            }
        }

        private void backStripButton_Click(object sender, EventArgs e)
        {
            NavigateBackward();
        }

        private void forwardStripButton_Click(object sender, EventArgs e)
        {
            NavigateForward();
        }

        DateTime lastNavigatedDateTime = DateTime.Now;

        private bool NavigateBackward()
        {
            DateTime max = new DateTime();
            int iLine = -1;
            FastColoredTextBox tb = null;
            for (int iTab = 0; iTab < tsFiles.Items.Count; iTab++)
            {
                var t = (tsFiles.Items[iTab].Controls[0] as FastColoredTextBox);
                for (int i = 0; i < t.LinesCount; i++)
                    if (t[i].LastVisit < lastNavigatedDateTime && t[i].LastVisit > max)
                    {
                        max = t[i].LastVisit;
                        iLine = i;
                        tb = t;
                    }
            }
            if (iLine >= 0)
            {
                tsFiles.SelectedItem = (tb.Parent as FATabStripItem);
                tb.Navigate(iLine);
                lastNavigatedDateTime = tb[iLine].LastVisit;
                Console.WriteLine("Backward: " + lastNavigatedDateTime);
                tb.Focus();
                tb.Invalidate();
                return true;
            }
            else
                return false;
        }

        private bool NavigateForward()
        {
            DateTime min = DateTime.Now;
            int iLine = -1;
            FastColoredTextBox tb = null;
            for (int iTab = 0; iTab < tsFiles.Items.Count; iTab++)
            {
                var t = (tsFiles.Items[iTab].Controls[0] as FastColoredTextBox);
                for (int i = 0; i < t.LinesCount; i++)
                    if (t[i].LastVisit > lastNavigatedDateTime && t[i].LastVisit < min)
                    {
                        min = t[i].LastVisit;
                        iLine = i;
                        tb = t;
                    }
            }
            if (iLine >= 0)
            {
                tsFiles.SelectedItem = (tb.Parent as FATabStripItem);
                tb.Navigate(iLine);
                lastNavigatedDateTime = tb[iLine].LastVisit;
                Console.WriteLine("Forward: " + lastNavigatedDateTime);
                tb.Focus();
                tb.Invalidate();
                return true;
            }
            else
                return false;
        }

        private void autoIndentSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.DoAutoIndent();
        }

        private void btInvisibleChars_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in tsFiles.Items)
                HighlightInvisibleChars((tab.Controls[0] as FastColoredTextBox).Range);
            if (CurrentTB != null)
                CurrentTB.Invalidate();
        }

        private void btHighlightCurrentLine_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in tsFiles.Items)
            {
                if (btHighlightCurrentLine.Checked)
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = currentLineColor;
                else
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = Color.Transparent;
            }
            if (CurrentTB != null)
                CurrentTB.Invalidate();
        }

        private void commentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.InsertLinePrefix("//");
        }

        private void uncommentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTB.RemoveLinePrefix("//");
        }

        private void cloneLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //expand selection
            CurrentTB.Selection.Expand();
            //get text of selected lines
            string text = Environment.NewLine + CurrentTB.Selection.Text;
            //move caret to end of selected lines
            CurrentTB.Selection.Start = CurrentTB.Selection.End;
            //insert text
            CurrentTB.InsertText(text);
        }

        private void cloneLinesAndCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start autoUndo block
            CurrentTB.BeginAutoUndo();
            //expand selection
            CurrentTB.Selection.Expand();
            //get text of selected lines
            string text = Environment.NewLine + CurrentTB.Selection.Text;
            //comment lines
            CurrentTB.InsertLinePrefix("//");
            //move caret to end of selected lines
            CurrentTB.Selection.Start = CurrentTB.Selection.End;
            //insert text
            CurrentTB.InsertText(text);
            //end of autoUndo block
            CurrentTB.EndAutoUndo();
        }

        private void bookmarkPlusButton_Click(object sender, EventArgs e)
        {
            if (CurrentTB == null)
                return;
            CurrentTB.BookmarkLine(CurrentTB.Selection.Start.iLine);
        }

        private void bookmarkMinusButton_Click(object sender, EventArgs e)
        {
            if (CurrentTB == null)
                return;
            CurrentTB.UnbookmarkLine(CurrentTB.Selection.Start.iLine);
        }

        private void gotoButton_DropDownOpening(object sender, EventArgs e)
        {
            gotoButton.DropDownItems.Clear();
            foreach (Control tab in tsFiles.Items)
            {
                FastColoredTextBox tb = tab.Controls[0] as FastColoredTextBox;
                foreach (var bookmark in tb.Bookmarks)
                {
                    var item = gotoButton.DropDownItems.Add(bookmark.Name + " [" + Path.GetFileNameWithoutExtension(tab.Tag as String) + "]");
                    item.Tag = bookmark;
                    item.Click += (o, a) =>
                    {
                        var b = (Bookmark)(o as ToolStripItem).Tag;
                        try
                        {
                            CurrentTB = b.TB;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        b.DoVisible();
                    };
                }
            }
        }

        private void btShowFoldingLines_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in tsFiles.Items)
                (tab.Controls[0] as FastColoredTextBox).ShowFoldingLines = btShowFoldingLines.Checked;
            if (CurrentTB != null)
                CurrentTB.Invalidate();
        }

        private void Zoom_click(object sender, EventArgs e)
        {
            if (CurrentTB != null)
                CurrentTB.Zoom = int.Parse((sender as ToolStripItem).Tag.ToString());
        }

        #endregion

        private void bar2_ItemClick(object sender, EventArgs e)
        {

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            treeConnection.LabelEdit = true;
            treeConnection.SelectedNode.BeginEdit();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;
            //CreateTab(ofdMain.FileName);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (tsFiles.SelectedItem != null)
                Save(tsFiles.SelectedItem);
        }

        private void btnGenerateSql_Click(object sender, EventArgs e)
        {
            FrmGenerateSql gen = new FrmGenerateSql();
            gen.TopLevel = false;
            var tab = new FATabStripItem("GenerateSql", gen);
            tsFiles.AddTab(tab);
            gen.Dock = DockStyle.Fill;
            gen.Show();
        }

        private void btnSelectLeftConnection_Click(object sender, EventArgs e)
        {
            NodeA = (TreeNodeConnection)treeConnection.SelectedNode;
        }

        private void btnLeftToCompare_Click(object sender, EventArgs e)
        {
            try
            {
                waitForm.Show();
                NodeB = (TreeNodeConnection)treeConnection.SelectedNode;

                DatabaseInfo dbA = new DatabaseInfo();
                dbA.Connection = NodeA.Connection;
                dbA.Name = NodeA.Text;

                DatabaseInfo dbB = new DatabaseInfo();
                dbB.Connection = NodeB.Connection;
                dbB.Name = NodeB.Text;

                NodeA = null;
                NodeB = null;

                var tabName = dbA.Name + " vs " + dbB.Name;
                //if(tsFiles.Items.IndexOf
                FrmCompare gen = new FrmCompare(dbA, dbB);
                gen.TopLevel = false;
                gen.Dock = DockStyle.Fill;
                var tab = new FATabStripItem(tabName, gen);

                if (!tsFiles.Items.Cast<FATabStripItem>().ToList().Exists(s => s.Caption == tabName))
                {
                    tsFiles.AddTab(tsFiles.SelectedItem = tab);
                    gen.Dock = DockStyle.Fill;
                    gen.Show();
                }
                else
                {
                    tsFiles.SelectedItem = tsFiles.Items.Cast<FATabStripItem>().ToList().Single(s => s.Caption == tabName);
                }
            }
            catch { }
            finally
            {
                waitForm.Close();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            treeConnection.SelectedNode.ImageIndex = Constant.Img_NewConnection;
            treeConnection.SelectedNode.SelectedImageIndex = Constant.Img_NewConnection;

            tsFiles.Items.Remove(tsFiles.Items.Cast<FATabStripItem>().ToList().SingleOrDefault(s => s.Caption == treeConnection.SelectedNode.Text));
        }

        private void tsFiles_TabStripItemSelectionChanged_1(TabStripItemChangedEventArgs e)
        {

        }
    }
}
