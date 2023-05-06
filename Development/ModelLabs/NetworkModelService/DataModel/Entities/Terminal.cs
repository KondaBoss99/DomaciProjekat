using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Entities
{
    public class Terminal : IdentifiedObject
    {
		private long connectivityNode;
		private long conductingEquipment;
		private List<long> measurements = new List<long>();

		public Terminal(long globalId) : base(globalId)
		{
		}
		public long ConnectivityNode
		{
			get
			{
				return connectivityNode;
			}

			set
			{
				connectivityNode = value;
			}
		}

		public long ConductingEquipment
		{
			get
			{
				return conductingEquipment;
			}

			set
			{
				conductingEquipment = value;
			}
		}

		public List<long> Measurements
		{
			get
			{
				return measurements;
			}

			set
			{
				measurements = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Terminal x = (Terminal)obj;
				return ((x.ConductingEquipment == this.ConnectivityNode) &&
						(x.ConnectivityNode == this.ConductingEquipment) &&
						(CompareHelper.CompareLists(x.measurements, this.measurements)));
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
				case ModelCode.TERMINAL_CONNECTIVITYNODE:
					return true;
				case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
					return true;
				case ModelCode.TERMINAL_MEASUREMENTS:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.TERMINAL_CONNECTIVITYNODE:
					prop.SetValue(connectivityNode);
					break;
				case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
					prop.SetValue(conductingEquipment);
					break;
				case ModelCode.TERMINAL_MEASUREMENTS:
					prop.SetValue(measurements);
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
				case ModelCode.TERMINAL_CONNECTIVITYNODE:
					connectivityNode = property.AsReference();
					break;
				case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
					conductingEquipment = property.AsReference();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation	

		#region IReference implementation

		public override bool IsReferenced
		{
			get
			{
				return measurements.Count > 0 || base.IsReferenced;
			}
		}

		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (connectivityNode != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.TERMINAL_CONNECTIVITYNODE] = new List<long>();
				references[ModelCode.TERMINAL_CONNECTIVITYNODE].Add(connectivityNode);
			}
			if (conductingEquipment != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.TERMINAL_CONDUCTINGEQUIPMENT] = new List<long>();
				references[ModelCode.TERMINAL_CONDUCTINGEQUIPMENT].Add(conductingEquipment);
			}
			if (measurements != null && measurements.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
			{
				references[ModelCode.TERMINAL_MEASUREMENTS] = measurements.GetRange(0, measurements.Count);
			}

			base.GetReferences(references, refType);
		}

		public override void AddReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				case ModelCode.MEASUREMENT_TERMINAL:
					measurements.Add(globalId);
					break;

				default:
					base.AddReference(referenceId, globalId);
					break;
			}
		}

		public override void RemoveReference(ModelCode referenceId, long globalId)
		{
			switch (referenceId)
			{
				case ModelCode.MEASUREMENT_TERMINAL:

					if (measurements.Contains(globalId))
					{
						measurements.Remove(globalId);
					}
					else
					{
						CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
					}

					break;

				default:
					base.RemoveReference(referenceId, globalId);
					break;
			}
		}

		#endregion IReference implementation	
	}
}
