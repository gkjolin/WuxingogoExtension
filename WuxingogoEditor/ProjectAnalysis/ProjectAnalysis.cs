//
//  ProjectAnalysis.cs
//
//  Author:
//       ${wuxingogo} <52111314ly@gmail.com>
//
//  Copyright (c) 2015 ly-user
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using wuxingogo.tools;
using System.Reflection;


namespace wuxingogo.analysis
{

	public class ProjectAnalysis : SingletonT<ProjectAnalysis>
	{
		
		public void GetAssembly(){
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			
			
		}
	}
}

