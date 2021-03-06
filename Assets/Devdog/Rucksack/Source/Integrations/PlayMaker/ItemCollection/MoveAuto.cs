﻿using HutongGames.PlayMaker;

namespace Devdog.Rucksack.Integrations.PlayMaker
{
    [ActionCategory(RucksackConstants.ProductName + "/ItemCollection")]
    public class MoveAuto : ItemCollectionAction
    {
        public FsmInt fromIndex;
        
        [RequiredField]
        [ObjectType(typeof(ItemCollectionWrapper))]
        public FsmObject toCollection;
        
        public override void OnEnter()
        {
            var fromCol = (ItemCollectionWrapper)collection.Value;
            var toCol = (ItemCollectionWrapper)toCollection.Value;
            
            var result = fromCol.collection.MoveAuto(fromIndex.Value, toCol.collection, fromCol.collection.GetAmount(fromIndex.Value));
            if (result.error != null)
            {
                LogWarning(result.error.ToString());
            }
            
            Finish();
        }
    }
}