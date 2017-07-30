/// <binding BeforeBuild='clean, copy' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var clean = require('gulp-clean')


gulp.task("clean", function () {
    return gulp.src("Scripts/*", { read: false })
        .pipe(clean());
});

gulp.task('copy', function () {
    gulp.src('wwwroot/lib/bootstrap/dist/**/*')
        .pipe(gulp.dest('Scripts/lib/bootstrap'))

    gulp.src('wwwroot/lib/datatables.net/js/*')
        .pipe(gulp.dest('Scripts/lib/datatables.net'))

    gulp.src('wwwroot/lib/datatables.net-bs/**/*')
        .pipe(gulp.dest('Scripts/lib/datatables.net-bs'))

    gulp.src('wwwroot/lib/jquery/dist/*')
        .pipe(gulp.dest('Scripts/lib/jquery'))

    gulp.src('wwwroot/lib/vue/dist/*')
        .pipe(gulp.dest('Scripts/lib/vue'))

    gulp.src('wwwroot/app/**/*')
        .pipe(gulp.dest('Scripts/app'))
});