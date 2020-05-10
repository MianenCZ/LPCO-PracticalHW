using System;
using System.Diagnostics;
using Xunit;

namespace SolTests
{
    public class UnitTest1
    {
        [Theory]
        #region Data
        [InlineData("vstup-s0.txt", 36)]
        [InlineData("vstup-s1.txt", 41)]
        [InlineData("vstup-s2.txt", 67)]
        [InlineData("vstup-s3.txt", 31)]
        [InlineData("vstup-s4.txt", 34)]
        [InlineData("vstup-s5.txt", 33)]
        [InlineData("vstup-s6.txt", 50)]
        [InlineData("vstup-s7.txt", 31)]
        [InlineData("vstup-s8.txt", 60)]
        [InlineData("vstup-s9.txt", 0)]
        [InlineData("vstup-000.txt", 2004)]
        [InlineData("vstup-001.txt", 1787)]
        [InlineData("vstup-002.txt", 1946)]
        [InlineData("vstup-003.txt", 1742)]
        [InlineData("vstup-004.txt", 1693)]
        [InlineData("vstup-005.txt", 2060)]
        [InlineData("vstup-006.txt", 2025)]
        [InlineData("vstup-007.txt", 1774)]
        [InlineData("vstup-008.txt", 1583)]
        [InlineData("vstup-009.txt", 1752)]
        [InlineData("vstup-010.txt", 1873)]
        [InlineData("vstup-011.txt", 2065)]
        [InlineData("vstup-012.txt", 1959)]
        [InlineData("vstup-013.txt", 2033)]
        [InlineData("vstup-014.txt", 1906)]
        [InlineData("vstup-015.txt", 1845)]
        [InlineData("vstup-016.txt", 1865)]
        [InlineData("vstup-017.txt", 1934)]
        [InlineData("vstup-018.txt", 1765)]
        [InlineData("vstup-019.txt", 1901)]
        [InlineData("vstup-020.txt", 1713)]
        [InlineData("vstup-021.txt", 1969)]
        [InlineData("vstup-022.txt", 1981)]
        [InlineData("vstup-023.txt", 1959)]
        [InlineData("vstup-024.txt", 1806)]
        [InlineData("vstup-025.txt", 2091)]
        [InlineData("vstup-026.txt", 1834)]
        [InlineData("vstup-027.txt", 2038)]
        [InlineData("vstup-028.txt", 1928)]
        [InlineData("vstup-029.txt", 1950)]
        [InlineData("vstup-030.txt", 1778)]
        [InlineData("vstup-031.txt", 1865)]
        [InlineData("vstup-032.txt", 1843)]
        [InlineData("vstup-033.txt", 1922)]
        [InlineData("vstup-034.txt", 1874)]
        [InlineData("vstup-035.txt", 2009)]
        [InlineData("vstup-036.txt", 1908)]
        [InlineData("vstup-037.txt", 1987)]
        [InlineData("vstup-038.txt", 1878)]
        [InlineData("vstup-039.txt", 1945)]
        [InlineData("vstup-040.txt", 1872)]
        [InlineData("vstup-041.txt", 1882)]
        [InlineData("vstup-042.txt", 1932)]
        [InlineData("vstup-043.txt", 1932)]
        [InlineData("vstup-044.txt", 1839)]
        [InlineData("vstup-045.txt", 1934)]
        [InlineData("vstup-046.txt", 1923)]
        [InlineData("vstup-047.txt", 1857)]
        [InlineData("vstup-048.txt", 2179)]
        [InlineData("vstup-049.txt", 1827)]
        [InlineData("vstup-050.txt", 1740)]
        [InlineData("vstup-051.txt", 1943)]
        [InlineData("vstup-052.txt", 1993)]
        [InlineData("vstup-053.txt", 1957)]
        [InlineData("vstup-054.txt", 2050)]
        [InlineData("vstup-055.txt", 1969)]
        [InlineData("vstup-056.txt", 2213)]
        [InlineData("vstup-057.txt", 1781)]
        [InlineData("vstup-058.txt", 1854)]
        [InlineData("vstup-059.txt", 2006)]
        [InlineData("vstup-060.txt", 1927)]
        [InlineData("vstup-061.txt", 2060)]
        [InlineData("vstup-062.txt", 2073)]
        [InlineData("vstup-063.txt", 1784)]
        [InlineData("vstup-064.txt", 1973)]
        [InlineData("vstup-065.txt", 1778)]
        [InlineData("vstup-066.txt", 1861)]
        [InlineData("vstup-067.txt", 1945)]
        [InlineData("vstup-068.txt", 1829)]
        [InlineData("vstup-069.txt", 1941)]
        [InlineData("vstup-070.txt", 1901)]
        [InlineData("vstup-071.txt", 1898)]
        [InlineData("vstup-072.txt", 1941)]
        [InlineData("vstup-073.txt", 1742)]
        [InlineData("vstup-074.txt", 1722)]
        [InlineData("vstup-075.txt", 1910)]
        [InlineData("vstup-076.txt", 1796)]
        [InlineData("vstup-077.txt", 1732)]
        [InlineData("vstup-078.txt", 1895)]
        [InlineData("vstup-079.txt", 1917)]
        [InlineData("vstup-080.txt", 1858)]
        [InlineData("vstup-081.txt", 1844)]
        [InlineData("vstup-082.txt", 1711)]
        [InlineData("vstup-083.txt", 1950)]
        [InlineData("vstup-084.txt", 1928)]
        [InlineData("vstup-085.txt", 2051)]
        [InlineData("vstup-086.txt", 1885)]
        [InlineData("vstup-087.txt", 1946)]
        [InlineData("vstup-088.txt", 1921)]
        [InlineData("vstup-089.txt", 1940)]
        [InlineData("vstup-090.txt", 1771)]
        [InlineData("vstup-091.txt", 1771)]
        [InlineData("vstup-092.txt", 1754)]
        [InlineData("vstup-093.txt", 1696)]
        [InlineData("vstup-094.txt", 1867)]
        [InlineData("vstup-095.txt", 1793)]
        [InlineData("vstup-096.txt", 1795)]
        [InlineData("vstup-097.txt", 1884)]
        [InlineData("vstup-098.txt", 2046)]
        [InlineData("vstup-099.txt", 1968)]
        [InlineData("vstup-100.txt", 1798)]
        [InlineData("vstup-101.txt", 1828)]
        [InlineData("vstup-102.txt", 1910)]
        [InlineData("vstup-103.txt", 1751)]
        [InlineData("vstup-104.txt", 2059)]
        [InlineData("vstup-105.txt", 1951)]
        [InlineData("vstup-106.txt", 1919)]
        [InlineData("vstup-107.txt", 1979)]
        [InlineData("vstup-108.txt", 2037)]
        [InlineData("vstup-109.txt", 2076)]
        [InlineData("vstup-110.txt", 1996)]
        [InlineData("vstup-111.txt", 2020)]
        [InlineData("vstup-112.txt", 1833)]
        [InlineData("vstup-113.txt", 1936)]
        [InlineData("vstup-114.txt", 1905)]
        [InlineData("vstup-115.txt", 1825)]
        [InlineData("vstup-116.txt", 1916)]
        [InlineData("vstup-117.txt", 1795)]
        [InlineData("vstup-118.txt", 1837)]
        [InlineData("vstup-119.txt", 1847)]
        [InlineData("vstup-120.txt", 1949)]
        [InlineData("vstup-121.txt", 2014)]
        [InlineData("vstup-122.txt", 1963)]
        [InlineData("vstup-123.txt", 1688)]
        [InlineData("vstup-124.txt", 1918)]
        [InlineData("vstup-125.txt", 1889)]
        [InlineData("vstup-126.txt", 1997)]
        [InlineData("vstup-127.txt", 1942)]
        [InlineData("vstup-128.txt", 1968)]
        [InlineData("vstup-129.txt", 1980)]
        [InlineData("vstup-130.txt", 1848)]
        [InlineData("vstup-131.txt", 1960)]
        [InlineData("vstup-132.txt", 2015)]
        [InlineData("vstup-133.txt", 2011)]
        [InlineData("vstup-134.txt", 1784)]
        [InlineData("vstup-135.txt", 1994)]
        [InlineData("vstup-136.txt", 1989)]
        [InlineData("vstup-137.txt", 1787)]
        [InlineData("vstup-138.txt", 1969)]
        [InlineData("vstup-139.txt", 1713)]
        [InlineData("vstup-140.txt", 1974)]
        [InlineData("vstup-141.txt", 1953)]
        [InlineData("vstup-142.txt", 1983)]
        [InlineData("vstup-143.txt", 1811)]
        [InlineData("vstup-144.txt", 1887)]
        [InlineData("vstup-145.txt", 1945)]
        [InlineData("vstup-146.txt", 1966)]
        [InlineData("vstup-147.txt", 1993)]
        [InlineData("vstup-148.txt", 1831)]
        [InlineData("vstup-149.txt", 1714)]
        [InlineData("vstup-150.txt", 1849)]
        [InlineData("vstup-151.txt", 1809)]
        [InlineData("vstup-152.txt", 2098)]
        [InlineData("vstup-153.txt", 1966)]
        [InlineData("vstup-154.txt", 1900)]
        [InlineData("vstup-155.txt", 2142)]
        [InlineData("vstup-156.txt", 1882)]
        [InlineData("vstup-157.txt", 1894)]
        [InlineData("vstup-158.txt", 2001)]
        [InlineData("vstup-159.txt", 1980)]
        [InlineData("vstup-160.txt", 1773)]
        [InlineData("vstup-161.txt", 2073)]
        [InlineData("vstup-162.txt", 1949)]
        [InlineData("vstup-163.txt", 2085)]
        [InlineData("vstup-164.txt", 1734)]
        [InlineData("vstup-165.txt", 1881)]
        [InlineData("vstup-166.txt", 1757)]
        [InlineData("vstup-167.txt", 1853)]
        [InlineData("vstup-168.txt", 1983)]
        [InlineData("vstup-169.txt", 1854)]
        [InlineData("vstup-170.txt", 1841)]
        [InlineData("vstup-171.txt", 1839)]
        [InlineData("vstup-172.txt", 1655)]
        [InlineData("vstup-173.txt", 1822)]
        [InlineData("vstup-174.txt", 1907)]
        [InlineData("vstup-175.txt", 1935)]
        [InlineData("vstup-176.txt", 1897)]
        [InlineData("vstup-177.txt", 1941)]
        [InlineData("vstup-178.txt", 2112)]
        [InlineData("vstup-179.txt", 1839)]
        [InlineData("vstup-180.txt", 1975)]
        [InlineData("vstup-181.txt", 1826)]
        [InlineData("vstup-182.txt", 1938)]
        [InlineData("vstup-183.txt", 1839)]
        [InlineData("vstup-184.txt", 1975)]
        [InlineData("vstup-185.txt", 1796)]
        [InlineData("vstup-186.txt", 1894)]
        [InlineData("vstup-187.txt", 1744)]
        [InlineData("vstup-188.txt", 1732)]
        [InlineData("vstup-189.txt", 1826)]
        [InlineData("vstup-190.txt", 1959)]
        [InlineData("vstup-191.txt", 2089)]
        [InlineData("vstup-192.txt", 1821)]
        [InlineData("vstup-193.txt", 1694)]
        [InlineData("vstup-194.txt", 1793)]
        [InlineData("vstup-195.txt", 2017)]
        [InlineData("vstup-196.txt", 1964)]
        [InlineData("vstup-197.txt", 1936)]
        [InlineData("vstup-198.txt", 1744)]
        [InlineData("vstup-199.txt", 1966)]
        //*/
        #endregion
        public void Test1(string file, int target)
        {
            NonTS.Program.Main(new[] { file });

            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = $"-m {file}.out";
            start.FileName = "glpsol";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;

            int exitCode;

            using (Process proc = Process.Start(start))
            {
                var read = proc.StandardOutput;
                int sum = 0;
                string[] lines = read.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                bool reading = false;


                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (line.Contains("#OUTPUT END"))
                    {
                        reading = false;
                    }
                    if (reading)
                    {
                        string[] data = line.Split(new[] { "-->", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                        sum += int.Parse(data[2]);
                    }
                    if (line.Contains("#OUTPUT:"))
                    {
                        reading = true;
                    }
                }
                proc.WaitForExit();
                exitCode = proc.ExitCode;

                Assert.Equal(target, sum);
            }



        }
    }
}



