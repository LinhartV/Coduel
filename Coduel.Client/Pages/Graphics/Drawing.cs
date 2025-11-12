namespace Coduel.Client.Pages
{
    public partial class Index
    {
        int x = 0;
        int y = 1;

        async Task DrawFrame(double fps)
        {
            await this.Ctx.ClearRectAsync(0, 0, size.Width, size.Height);
            await this.OffscreenCtx.ClearRectAsync(0, 0, size.Width, size.Height);
            await this.Ctx.DrawImageAsync(BackgroundCanvasReference.CanvasReference, 0, 0);
            await DrawItems();
            await DrawFPS(fps);
            await this.Ctx.DrawImageAsync(OffscreenCanvasReference.CanvasReference, 0, 0);
        }

        async Task DrawBackground()
        {
            await this.BackgroundCtx.SetFillStyleAsync("#DBDBDB");
            await this.BackgroundCtx.FillRectAsync(0, 0, size.Width, size.Height);

            await this.BackgroundCtx.SetStrokeStyleAsync("#D2D2D2");

            for (int i = 0; i < size.Width/LINE_SPACE; i++)
            {
                await this.BackgroundCtx.BeginPathAsync();
                await this.BackgroundCtx.MoveToAsync((i+1)* LINE_SPACE, 0);
                await this.BackgroundCtx.LineToAsync((i + 1) * LINE_SPACE, size.Height);
                await this.BackgroundCtx.StrokeAsync();
            }
            for (int i = 0; i < size.Height / LINE_SPACE; i++)
            {
                await this.BackgroundCtx.BeginPathAsync();
                await this.BackgroundCtx.MoveToAsync(0,(i + 1) * LINE_SPACE);
                await this.BackgroundCtx.LineToAsync(size.Width,(i + 1) * LINE_SPACE);
                await this.BackgroundCtx.StrokeAsync();
            }
        }
        async Task DrawFPS(double fps)
        {
            await this.OffscreenCtx.SetFontAsync("13px Segoe UI");
            await this.OffscreenCtx.SetFillStyleAsync("black");
            await this.OffscreenCtx.FillTextAsync("Blazor Canvas", 10, 30);

            await this.OffscreenCtx.SetFontAsync("16px consolas");
            await this.OffscreenCtx.FillTextAsync($"FPS: {fps:0.000}", 10, 50);
        }
        async Task DrawItems()
        {
            x++;
            y += 2;
            if (x>size.Width)
            {
                x = 0;
            }
            if (y > size.Height)
            {
                y = 1;
            }
            await this.OffscreenCtx.BeginPathAsync();
            await this.OffscreenCtx.ArcAsync(x, y, 10, 0, 2 * Math.PI, false);
            await this.OffscreenCtx.SetFillStyleAsync("red");
            await this.OffscreenCtx.FillAsync();
            await this.OffscreenCtx.SetStrokeStyleAsync("black");
            await this.OffscreenCtx.StrokeAsync();
        }
    }

}
