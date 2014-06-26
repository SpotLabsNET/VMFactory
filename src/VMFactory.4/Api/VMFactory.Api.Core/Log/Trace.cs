using System;

namespace VMFactory.Api.Core.Log
{
    [Serializable]
    public class Entry
    {
        private string _entity = string.Empty;
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public string Entity { get { return _entity; } set { _entity = value; } }

        private string _id = string.Empty;
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get { return _id; } set { _id = value; } }

        private string _msg = string.Empty;
        /// <summary>
        /// Gets or sets the MSG.
        /// </summary>
        /// <value>
        /// The MSG.
        /// </value>
        public string Msg { get { return _msg; } set { _msg = value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return string.Format( @"<log><entity>{0}</entity><id>{1}</id><msg>{2}</msg><log>", string.IsNullOrEmpty(this.Entity) ? "" : this.Entity, string.IsNullOrEmpty(this.Id) ? "" : this.Id, string.IsNullOrEmpty(this.Msg) ? "" : this.Msg); }
    }
}
