using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpineViewer.Spine
{
    /// <summary>
    /// 骨骼列表管理器
    /// </summary>
    class Manager
    {
        /// <summary>
        /// 骨骼列表
        /// </summary>
        public ReadOnlyCollection<Spine> Spines { get => spines.AsReadOnly(); }
        private readonly List<Spine> spines = [];

        private readonly ListView listView;

        /// <summary>
        /// 骨骼管理器
        /// </summary>
        /// <param name="listView">用于显示骨骼信息的列表</param>
        public Manager(ListView listView)
        {
            listView.BeginUpdate();
            listView.Columns.Clear();
            listView.Items.Clear();
            listView.Columns.AddRange([
                new() { Text = "名称", Width = 150}, 
                new() { Text = "版本", Width = 150 }
            ]);
            listView.EndUpdate();
            this.listView = listView;
        }

        /// <summary>
        /// 在末尾添加一个
        /// </summary>
        public void Add(Spine spine)
        {
            spines.Add(spine);
            listView.Items.Add(new ListViewItem([
                Path.GetFileNameWithoutExtension(spine.SkelPath),
                spine.Version.String()
            ], -1)
            { ToolTipText = spine.SkelPath });
        }

        /// <summary>
        /// 在指定下标之前添加一个
        /// </summary>
        public void Insert(int index, Spine spine)
        {
            spines.Insert(index, spine);
            listView.Items.Insert(index, new ListViewItem([
                Path.GetFileNameWithoutExtension(spine.SkelPath),
                spine.Version.String()
            ], -1)
            { ToolTipText = spine.SkelPath });
        }

        /// <summary>
        /// 批量移除
        /// </summary>
        public void Remove(IEnumerable<int> indices) 
        { 
            foreach (var i in indices.OrderByDescending(x => x)) 
            { 
                spines.RemoveAt(i); 
                listView.Items.RemoveAt(i);
            } 
        }

        /// <summary>
        /// 指定下标元素前移一位
        /// </summary>
        public void MoveUp(int index) 
        {
            if (index > 0) 
            { 
                (spines[index - 1], spines[index]) = (spines[index], spines[index - 1]);
                var item = listView.Items[index];
                listView.Items.RemoveAt(index);
                listView.Items.Insert(index - 1, item);
            } 
        }

        /// <summary>
        /// 指定下标元素后移一位
        /// </summary>
        public void MoveDown(int index) 
        { 
            if (index < spines.Count - 1) 
            { 
                (spines[index], spines[index + 1]) = (spines[index + 1], spines[index]);
                var item = listView.Items[index + 1];
                listView.Items.RemoveAt(index + 1);
                listView.Items.Insert(index, item);
            } 
        }

        /// <summary>
        /// 全部移除
        /// </summary>
        public void Clear() 
        { 
            spines.Clear(); 
            listView.Clear();
        }
    }
}
