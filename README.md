# C#

## 基础

### 做一个屏保

![](http://cdn.zhaojingyi0126.com/IMG/image-20200511105621798.png)

代码：https://github.com/yangyang0126/CSharp/tree/master/ScreenSaver

### 自动出题器

![](http://cdn.zhaojingyi0126.com/IMG/image-20200511105359461.png)

默认出题数字是1-10，可通过`rnd.Next(10)`修改

代码：https://github.com/yangyang0126/CSharp/tree/master/AutoScore

### 画很多圆

![](http://cdn.zhaojingyi0126.com/IMG/image-20200511105931772.png)

```c#
g.DrawEllipse(
    new Pen(getRandomColor(), 1),
    x0 - r, y0 - r, r * 2, r * 2  // 修改参数，可以绘制各种图形
);
```

### 排块游戏

![image-20200511132109405](http://cdn.zhaojingyi0126.com/IMG/image-20200511132109405.png)