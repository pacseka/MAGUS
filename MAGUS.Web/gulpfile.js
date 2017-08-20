/// <binding BeforeBuild='clean, copy' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var clean = require('gulp-clean')


gulp.task("clean", function () {
    return gulp.src("Scripts/lib/*", { read: false })
        .pipe(clean());
});

gulp.task('copy', function () {
    gulp.src('node_modules/bootstrap/dist/**/*')
        .pipe(gulp.dest('Scripts/lib/bootstrap'));

    gulp.src('node_modules/jquery/dist/*')
        .pipe(gulp.dest('Scripts/lib/jquery'));

    gulp.src('node_modules/vue/dist/*')
        .pipe(gulp.dest('Scripts/lib/vue'));

    gulp.src('node_modules/vue-infinite-loading/dist/vue-infinite-loading.js')
        .pipe(gulp.dest('Scripts/lib/vue-infinite-loading'));

    gulp.src('node_modules/vee-validate/dist/locale/hu.js')
        .pipe(gulp.dest('Scripts/lib/vee-validate/locale'));

    gulp.src('node_modules/vee-validate/dist/vee-validate.js')
        .pipe(gulp.dest('Scripts/lib/vee-validate'));

    gulp.src('node_modules/lodash/lodash.js')
        .pipe(gulp.dest("Scripts/lib/lodash"));
});