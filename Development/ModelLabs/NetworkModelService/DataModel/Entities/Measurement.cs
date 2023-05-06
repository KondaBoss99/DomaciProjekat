using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Entities
{
    public class Measurement : IdentifiedObject
    {
		private long terminal;
		private long powerSystemResource;

		public Measurement(long globalId) : base(globalId)
		{
		}
		public long Terminal
		{
			get
			{
				return terminal;
			}

			set
			{
				terminal = value;
			}
		}

		public long PowerSystemResource
		{
			get
			{
				return powerSystemResource;
			}

			set
			{
				powerSystemResource = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Measurement x = (Measurement)obj;
				return (x.Terminal == this.Terminal) &&
						(x.PowerSystemResource == this.PowerSystemResource);
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
				case ModelCode.MEASUREMENT_TERMINAL:
					return true;
				case ModelCode.MEASUREMENT_POWERSYSTEMRESOURCE:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.MEASUREMENT_TERMINAL:
					prop.SetValue(terminal);
					break;
				case ModelCode.MEASUREMENT_POWERSYSTEMRESOURCE:
					prop.SetValue(powerSystemResource);
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
				case ModelCode.MEASUREMENT_TERMINAL:
					terminal = property.AsReference();
					break;
				case ModelCode.MEASUREMENT_POWERSYSTEMRESOURCE:
					powerSystemResource = property.AsReference();
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
			if (terminal != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.MEASUREMENT_TERMINAL] = new List<long>();
				references[ModelCode.MEASUREMENT_TERMINAL].Add(terminal);
			}
			if (powerSystemResource != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.MEASUREMENT_POWERSYSTEMRESOURCE] = new List<long>();
				references[ModelCode.MEASUREMENT_POWERSYSTEMRESOURCE].Add(powerSystemResource);
			}

			base.GetReferences(references, refType);
		}

		#endregion IReference implementation	
	}
}
