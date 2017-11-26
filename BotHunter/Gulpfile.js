/// <binding AfterBuild='blocklyConcat, foundationCopyJs, foundationCopyCss, foundationCopyIcons' />
// подключаем Blockly
var gulp = require('gulp');
var concat = require('gulp-concat');

gulp.task('blocklyConcat', function () {
    gulp.src([
        "node_modules/blockly/blockly_compressed.js",
        "node_modules/blockly/javascript_compressed.js",
        "node_modules/blockly/blocks_compressed"
    ])
        .pipe(concat('blockly.js'))
        .pipe(gulp.dest("Scripts"));
});

// компилируем sass для Foundation
var gulp = require("gulp"),
    fs = require("fs"),
    sass = require("gulp-sass");

gulp.task('foundationCopyCss', function () {
    gulp.src([
        'node_modules/foundation-sites/dist/css/foundation.css',
        'node_modules/foundation-sites/dist/css/foundation-float.css',
        'node_modules/foundation-sites/dist/css/foundation-prototype.css',
        'node_modules/foundation-icons/foundation-icons.css'
    ])
        .pipe(concat('foundation.css'))
        // .pipe(sass())
        .pipe(gulp.dest('Content'));
});

gulp.task('foundationCopyIcons', function () {
    gulp.src([
        'node_modules/foundation-icons/foundation-icons.ttf',
        'node_modules/foundation-icons/foundation-icons.woff'
    ])
        .pipe(gulp.dest('Content'));
});

gulp.task('foundationCopyJs', function () {
    gulp.src('node_modules/foundation-sites/dist/js/foundation.js')
        .pipe(gulp.dest('Scripts'));
});