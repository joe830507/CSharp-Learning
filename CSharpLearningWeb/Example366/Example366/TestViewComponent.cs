using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Example366
{
    public class TestViewComponent : ViewComponent
    {
        IHostingEnvironment m_env = null;
        public TestViewComponent(IHostingEnvironment env)
        {
            m_env = env;
        }
        public IViewComponentResult Invoke()
        {
            return View("_showInfo", m_env);
        }
    }
}
