using FTN.Common;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Entities
{
    public class Equipment : PowerSystemResource
    {
		private bool aggregate;
		private bool normallyInService;
		private long equipmentContainer;

		public Equipment(long globalId) : base(globalId)
		{
		}
		public bool Aggregate
		{
			get
			{
				return aggregate;
			}

			set
			{
				aggregate = value;
			}
		}
		public bool NormallyInService
		{
			get
			{
				return normallyInService;
			}

			set
			{
				normallyInService = value;
			}
		}
		public long EquipmentContainer
		{
			get
			{
				return equipmentContainer;
			}

			set
			{
				equipmentContainer = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Equipment x = (Equipment)obj;
				return (x.Aggregate == this.Aggregate) &&
					   (x.NormallyInService == this.NormallyInService) &&
					   (x.EquipmentContainer == this.EquipmentContainer);
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}


		#region IAccess implementation

		public override bool HasProperty(ModelCode t)
		{
			switch (t)
			{
				case ModelCode.EQUIPMENT_AGGREGATE:
					return true;
				case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
					return true;
				case ModelCode.EQUIPMENT_EQUIPMENTCONTAINER:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.EQUIPMENT_AGGREGATE:
					prop.SetValue(aggregate);
					break;
				case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
					prop.SetValue(normallyInService);
					break;
				case ModelCode.EQUIPMENT_EQUIPMENTCONTAINER:
					prop.SetValue(equipmentContainer);
					break;

				default:
					base.GetProperty(prop);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.EQUIPMENT_AGGREGATE:
					aggregate = property.AsBool();
					break;
				case ModelCode.EQUIPMENT_NORMALLYINSERVICE:
					normallyInService = property.AsBool();
					break;
				case ModelCode.EQUIPMENT_EQUIPMENTCONTAINER:
					equipmentContainer = property.AsReference();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation	

		#region IReference implementation

		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (equipmentContainer != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.EQUIPMENT_EQUIPMENTCONTAINER] = new List<long>();
				references[ModelCode.EQUIPMENT_EQUIPMENTCONTAINER].Add(equipmentContainer);
			}

			base.GetReferences(references, refType);
		}

		#endregion IReference implementation	
	}
}
