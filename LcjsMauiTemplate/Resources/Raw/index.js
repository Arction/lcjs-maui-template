
const {
    lightningChart,
    SolidFill,
    SolidLine,
    AxisScrollStrategies,
    AxisTickStrategies,
    ColorRGBA,
    UIElementBuilders,
    Themes,
} = lcjs

const { createProgressiveTraceGenerator } = xydata

const chart = lightningChart().ChartXY()
    .setTitle(`LCJS x MAUI`)

const seriesList = [
    chart.addLineSeries({ dataPattern: { pattern: 'ProgressiveX' } }),
    chart.addPointLineSeries({ dataPattern: { pattern: 'ProgressiveX' } }),
    chart.addPointSeries(),
    chart.addStepSeries(),
    chart.addSplineSeries(),
]

seriesList.forEach((series, iSeries) =>
    createProgressiveTraceGenerator()
        .setNumberOfPoints(10000)
        .generate()
        .setStreamBatchSize(1)
        .setStreamInterval(200)
        .toStream()
        .forEach(point => series.add({ x: point.x, y: point.y + iSeries * 1 }))
)
