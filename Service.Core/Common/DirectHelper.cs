using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public class DirectHelper
    {

        /// <summary>
        /// 创建文件夹
        /// </summary> 
        public static void CreateFolder(string argPath)
        {

            try
            {
                if (!System.IO.Directory.Exists(argPath))
                {
                    System.IO.DirectoryInfo dirinfo = System.IO.Directory.CreateDirectory(argPath);
                }

            }
            catch (Exception ee)
            {
                throw ee;
            }

        }

        /// <summary>
        /// 递归删除文件夹及文件
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolder(string dir)
        {
            //取消屏蔽 执行该方法后，可以保留根文件夹(仅删除目录下的所有子)
            //// 检查目标目录是否以目录分割字符结束如果不是则添加之
            //if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
            //    dir += Path.DirectorySeparatorChar;

            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件 
                    else
                        DeleteFolder(d); //递归删除子文件夹 
                }
                Directory.Delete(dir); //删除已空文件夹 
                Console.Write(dir + " 文件夹删除成功");
            }
            else
                Console.Write(dir + " 该文件夹不存在"); //如果文件夹不存在则提示 
        }

        /// <summary>
        /// 实现一个静态方法将指定文件夹下面的所有内容copy到目标文件夹下面
        /// 如果目标文件夹为只读属性就会报错。
        /// </summary> 
        public static void CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                // 判断目标目录是否存在如果不存在则新建之
                if (!Directory.Exists(aimPath)) Directory.CreateDirectory(aimPath);
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles(srcPath);
                string[] fileList = Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (Directory.Exists(file))
                        CopyDir(file, aimPath + Path.GetFileName(file));
                    // 否则直接Copy文件
                    else
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                }
            }
            catch (Exception e)
            {
                
            }
        }
        /// <summary>
        /// 遍历 rootdir目录下的所有文件
        /// </summary>
        /// <param name="rootdir">目录名称</param>
        /// <returns>该目录下的所有文件</returns>
        public StringCollection GetAllFiles(string rootdir)
        {
            StringCollection result = new StringCollection();
            GetAllFiles(rootdir, result);
            return result;
        }
        /// <summary>
        /// 作为遍历文件函数的子函数
        /// </summary>
        /// <param name="parentDir">目录名称</param>
        /// <param name="result">该目录下的所有文件</param>
        public void GetAllFiles(string parentDir, StringCollection result)
        {
            //获取目录parentDir下的所有的子文件夹
            //string[] dir = Directory.GetDirectories(parentDir);
            //for (int i = 0; i < dir.Length; i++)
            //    GetAllFiles(dir[i], result);

            //获取目录parentDir下的所有的文件，并过滤得到所有的文本文件
            string[] file = Directory.GetFiles(parentDir, ".html");
            for (int i = 0; i < file.Length; i++)
            {
                //FileInfo fi = new FileInfo(file[i]);
                //if (fi.Extension.ToLower() == "txt")
                //{
                result.Add(file[i]);
                //}                
            }

        }
        public StringCollection GetAllFile(string path)
        {
            StringCollection result = new StringCollection();

            DirectoryInfo dir = new DirectoryInfo(path);
            //获取目录parentDir下的所有的文件，并过滤得到所有的文本文件
            var file = dir.GetFiles();
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Extension.ToLower() == ".html")
                    result.Add(file[i].FullName);

            }
            return result;
        }


        public void _GetAllFiles(string path, StringCollection tion)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo file in dir.GetFiles())//设置文件类型  
            {
                tion.Add(file.FullName); //网StringCollection里面添加文件名  

            }
            foreach (DirectoryInfo subDire in dir.GetDirectories()) //操作子目录  

            {
                _GetAllFiles(subDire.FullName, tion); //递归  
            }
        }

    }
}
