using MVVM;
using SharedKernel.View.Base;

namespace View.LookItemSelector
{
    public class LookItemSelectorListView : BaseView
    {
        [Data("Items")] 
        public CollectionView<LookItemSelectorView> Items;
    }
}