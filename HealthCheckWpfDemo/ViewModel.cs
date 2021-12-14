using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace HealthCheckWpfDemo
{
    public class ViewModel: INotifyPropertyChanged
    {
        private HealthContext _context;
        private ObservableCollection<TreeNode> nodes = new ObservableCollection<TreeNode>();
        private List<BloodItem> bloodItems;
        private List<CancerItem> cancerItems;
        private ObservableCollection<BloodItemDetails> blooditemDetails = new ObservableCollection<BloodItemDetails>();
        private ObservableCollection<Treatment> treatments = new ObservableCollection<Treatment>();
        private ObservableCollection<Treatment> selectedTreatment = new ObservableCollection<Treatment>();
        private Visibility bloodVisibility = Visibility.Hidden;
        private Visibility cancerVisibility = Visibility.Hidden;
        private int selectedTreeNode;

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TreeNode> Nodes
        {
            get { return nodes; }
            set
            {
                nodes = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Nodes"));
            }
        }

        public ObservableCollection<BloodItemDetails> BloodItemDetails
        {
            get { return blooditemDetails; }
            set
            {
                blooditemDetails = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BloodItemDetails"));
            }
        }

        public ObservableCollection<Treatment> CancerCheckItems
        {
            get { return treatments; }
            set
            {
                treatments = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CancerCheckItems"));
            }
        }

        public ObservableCollection<Treatment> SelectedTreatment
        {
            get { return selectedTreatment; }
            set
            {
                selectedTreatment = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedTreatment"));
            }
        }

        public Visibility BloodVisibility
        {
            get { return bloodVisibility; }
            set
            {
                bloodVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BloodVisibility"));
            }
        }

        public Visibility CancerVisibility
        {
            get { return cancerVisibility; }
            set
            {
                cancerVisibility = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CancerVisibility"));
            }
        }
       
        public DelegateCommand SelectedItemChangedCommand { get; }
        public DelegateCommand RemoveBloodItemCommand { get; }
        public DelegateCommand AddBloodItemCommand { get; }
        public DelegateCommand SaveBloodItemDetailsCommand { get; }
        public DelegateCommand ResetBloodItemDetailsCommand { get; }
        public DelegateCommand SelectedTreatmentChangedCommand { get; }
        public ViewModel()
        {
            _context = new HealthContext();
            bloodItems = _context.bloodItems.Include(b => b.details).ToList();
            cancerItems = _context.cancerItems.Include(c => c.treatments).ToList();
            InitTreeView();
            SelectedItemChangedCommand = new DelegateCommand(selectedItemChangedCommandHandler);
            RemoveBloodItemCommand = new DelegateCommand(removeBloodItemCommandHandler);
            SaveBloodItemDetailsCommand = new DelegateCommand(saveBloodItemDetailsCommandHandler);
            ResetBloodItemDetailsCommand = new DelegateCommand(resetBloodItemDetailsCommandHandler);
            SelectedTreatmentChangedCommand = new DelegateCommand(selectedTreatmentChangedCommandHandler);
        }

        private void InitTreeView()
        {
            int id = 1;
            TreeNode blood = new TreeNode()
            {
                id = id,
                pid = 0,
                name = "血液检查"
            };
            id++;
            TreeNode cancer = new TreeNode()
            {
                id = id,
                pid = 0,
                name = "癌症检查"
            };
            List<TreeNode> allNodes = new List<TreeNode>() { blood,cancer };
            foreach (var item in bloodItems)
            {
                id++;
                TreeNode _node = new TreeNode()
                {
                    id = id,
                    pid = blood.id,
                    name = item.name
                };
                allNodes.Add(_node);
            }

            foreach(var item in cancerItems)
            {
                id++;
                TreeNode _node = new TreeNode()
                {
                    id = id,
                    pid = cancer.id,
                    name = item.name
                };
                allNodes.Add(_node);
            }

            var _Nodes= getNodes(allNodes, 0);
            foreach (var node in _Nodes)
                Nodes.Add(node);

        }

        private List<TreeNode> getNodes(List<TreeNode> nodes,int pid)
        {
            var mainNodes = nodes.Where(x => x.pid == pid).ToList();
            var otherNodes = nodes.Where(x => x.pid != pid).ToList();
            foreach (var item in mainNodes)
                item.childnodes = getNodes(otherNodes, item.id);
            return mainNodes;
        }

        private void ResetVisibility()
        {
            BloodVisibility = Visibility.Hidden;
            CancerVisibility = Visibility.Hidden;
        }

        private void selectedItemChangedCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            TreeNode node = e.Parameter as TreeNode;
            if (node != null)
            {
                selectedTreeNode = node.id;
                if (node.pid == 1)
                {
                    ResetVisibility();
                    BloodVisibility = Visibility.Visible;
                    BloodItemDetails.Clear();
                    var details = bloodItems.Where(x => x.name == node.name).Single().details;
                    foreach (var item in details)
                        BloodItemDetails.Add(item);
                }
                else if (node.pid == 2)
                {
                    ResetVisibility();
                    CancerVisibility = Visibility.Visible;
                    CancerCheckItems.Clear();
                    var treatments = cancerItems.Where(x => x.name == node.name).Single().treatments;
                    foreach (var item in treatments)
                        CancerCheckItems.Add(item);
                }
            }
            
        }

        private void removeBloodItemCommandHandler(object sender, EventArgs e)
        {
            TreeNode node = Nodes[0].childnodes.Where(x => x.id == selectedTreeNode).SingleOrDefault();
            BloodItem removeItem = bloodItems.Where(x => x.name == node.name).SingleOrDefault();
            _context.Entry(removeItem).State = EntityState.Deleted;
            _context.SaveChanges();
            var node1 = Nodes[0];
            var node2 = Nodes[1];
            node1.childnodes.Remove(node);
            Nodes.Clear();
            Nodes.Add(node1);
            Nodes.Add(node2);
        }

        private void addBloodItemCommandHandler(object sender, EventArgs e)
        {

        }

        private void saveBloodItemDetailsCommandHandler(object sender, EventArgs e)
        {
            string name = Nodes[0].childnodes.Where(x => x.id == selectedTreeNode).SingleOrDefault().name;
            BloodItem item = bloodItems.Where(x => x.name == name).SingleOrDefault();
            item.details = BloodItemDetails.ToList();
            foreach(var child in item.details)
            {
                MessageBox.Show(child.id.ToString()+":"+child.standard);
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private void resetBloodItemDetailsCommandHandler(object sender, EventArgs e)
        {
            BloodItemDetails.Clear();
            string name = Nodes[0].childnodes.Where(x => x.id == selectedTreeNode).SingleOrDefault().name;
            var details = bloodItems.Where(x => x.name == name).Single().details;
            foreach (var item in details)
                BloodItemDetails.Add(item);
        }

        private void selectedTreatmentChangedCommandHandler(object sender, DelegateCommandEventArgs e)
        {
            SelectedTreatment.Clear();
            Treatment treat = e.Parameter as Treatment;
            SelectedTreatment.Add(treat);
        }
    }
}
