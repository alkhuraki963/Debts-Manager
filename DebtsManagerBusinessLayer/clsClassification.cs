using DebtsManagerDataAccessLayer;
using DebtsManagerUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtsManagerBusinessLayer
{
    public class clsClassification
    {
        enMode Mode;
        public int Id { get; private set; }
        public string Name { get; set; }

        public clsClassification()
        {
            this.Id = -1;
            this.Name = string.Empty;
            this.Mode = enMode.ADD;
        }

        private clsClassification(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
            Mode = enMode.UPDATE;
        }

        public static DataTable GetAllClassifications()
        {
            return clsClassificationDataAccess.GetAllClassifications();
        }

        public static clsClassification FindClassification(int ClassificationId)
        {
            string Name = string.Empty;

            if (clsClassificationDataAccess.GetClassificationById(ClassificationId, ref Name))
            {
                return new clsClassification(ClassificationId, Name);
            }
            else
            {
                return null;
            }
        }

        public static clsClassification FindClassification(string ClassificationName)
        {
            int classificationId = clsClassificationDataAccess.GetClassificationId(ClassificationName);

            if (classificationId > 0)
            {
                return FindClassification(classificationId);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.ADD:
                    {
                        if (_AddNewClassification())
                        {
                            Mode = enMode.UPDATE;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.UPDATE:
                    {
                        return _UpdateClassification();
                    }
            }
            return false;
        }

        private bool _UpdateClassification()
        {
            return clsClassificationDataAccess.UpdateClassification(this.Id, this.Name);
        }

        private bool _AddNewClassification()
        {
            this.Id = clsClassificationDataAccess.AddNewClassification(this.Name);
            return this.Id > 0;
        }

        public static bool IsClassificationExists(int ClassificationId)
        {
            return clsClassificationDataAccess.IsClassificationExists(ClassificationId);
        }

        public static bool IsClassificationExists(string ClassificationName)
        {
            return clsClassificationDataAccess.IsClassificationExistsByName(ClassificationName);
        }

        public static bool DeleteClassification(int ClassificationId)
        {
            if (IsClassificationExists(ClassificationId) && IsClassificationEmpty(ClassificationId))
            {
                return clsClassificationDataAccess.DeleteClassification(ClassificationId);
            }
            else
            {
                return false;
            }
        }

        private static bool IsClassificationEmpty(int classificationId)
        {
            return clsClassificationDataAccess.IsClassificationEmpty(classificationId);
        }

        public static int GetClassificationId(string ClassificationName)
        {
            return clsClassificationDataAccess.GetClassificationId(ClassificationName);
        }

        public static string GetClassificationName(int classificationId)
        {
            return clsClassificationDataAccess.GetClassificationName(classificationId);
        }

    }
}