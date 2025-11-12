using AvnCanvasHelper;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using System.Drawing;

namespace Coduel.Client.Pages
{
    public partial class Index
    {
        private double FPS;
        private Canvas2DContext Ctx;
        private BECanvasComponent CanvasReference;
        private CanvasHelper CanvasHelper;

        private Canvas2DContext OffscreenCtx;
        private BECanvasComponent OffscreenCanvasReference;
        private CanvasHelper OffscreenCanvasHelper;

        private Canvas2DContext BackgroundCtx;
        private BECanvasComponent BackgroundCanvasReference;
        private CanvasHelper BackgroundCanvasHelper;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Ctx = await CanvasReference.CreateCanvas2DAsync();
                await CanvasHelper.Initialize();
                OffscreenCtx = await OffscreenCanvasReference.CreateCanvas2DAsync();
                await OffscreenCanvasHelper.Initialize();

                BackgroundCtx = await BackgroundCanvasReference.CreateCanvas2DAsync();
                await BackgroundCanvasHelper.Initialize();
                await DrawBackground();
            }
        }
        /// <summary>
        /// Called by CanvasHelper whenever we are ready to render a frame
        /// </summary>
        /// <param name="fps"></param>
        /// <returns></returns>
        public async Task RenderFrame(double fps)
        {
            FPS = fps;
            await this.Ctx.BeginBatchAsync();
            await DrawFrame(fps);
            await this.Ctx.EndBatchAsync();
        }
        

        public void CanvasResized(Size size)
        {
            this.size = size;
        }


        void MouseDown(CanvasMouseArgs args)
        {
            DrawBackground();
        }


        void MouseUp(CanvasMouseArgs args)
        {

        }


        void MouseMove(CanvasMouseArgs args)
        {

        }
    }
}
