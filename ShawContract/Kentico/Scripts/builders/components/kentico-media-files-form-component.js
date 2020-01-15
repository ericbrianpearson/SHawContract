/*! Built with http://stenciljs.com */
const { h: e } = window.components; import { c as t } from "./chunk-f91cccde.js"; import "./chunk-a93dedfa.js"; class i { constructor() { this.selectedFiles = [], this.getSelectedValues = (() => this.selectedFiles && this.selectedFiles.length > 0 ? JSON.stringify(this.selectedFiles.map(e => ({ fileGuid: e.fileGuid }))) : ""), this.selectValues = (e => { this.selectedFiles = e, this.hiddenInput.dispatchEvent(new CustomEvent("change")) }) } componentWillLoad() { this.selectedData && (this.selectedFiles = JSON.parse(this.selectedData)) } componentDidLoad() { this.kenticoPropertiesDialogInputInit.emit(this.el) } render() { return e("div", null, 1 === this.maxFilesLimit ? e("kentico-media-files-single-form-component", { getString: this.getString, libraryName: this.libraryName, allowedExtensions: this.allowedExtensions, selectedFile: this.selectedFiles.length > 0 ? this.selectedFiles[0] : null, selectValues: this.selectValues }) : e("kentico-media-files-multiple-form-component", { getString: this.getString, libraryName: this.libraryName, maxFilesLimit: this.maxFilesLimit, allowedExtensions: this.allowedExtensions, selectedFiles: this.selectedFiles, selectValues: this.selectValues }), e("input", { type: "hidden", ref: e => this.hiddenInput = e, name: this.inputName, value: this.getSelectedValues() })) } static get is() { return "kentico-media-files-form-component" } static get properties() { return { allFilesShowed: { state: !0 }, allowedExtensions: { type: String, attr: "allowed-extensions" }, el: { elementRef: !0 }, getString: { type: "Any", attr: "get-string" }, inputName: { type: String, attr: "input-name" }, isListMode: { state: !0 }, libraryName: { type: String, attr: "library-name" }, maxFilesLimit: { type: Number, attr: "max-files-limit" }, selectedData: { type: String, attr: "selected-data" }, selectedFiles: { state: !0 } } } static get events() { return [{ name: "kenticoPropertiesDialogInputInit", method: "kenticoPropertiesDialogInputInit", bubbles: !0, cancelable: !0, composed: !0 }] } } const l = (e, t) => e ? e.name ? t("kentico.components.mediafileselector.fileerror") : t("kentico.components.mediafileselector.missingfile") : "", s = (e, t) => e ? e.isValid ? c(e) : a(e, t) : "", n = (e, t) => e ? e.isValid ? s(e, t) : e.name ? `${c(e)} - ${t("kentico.components.mediafileselector.fileerror.title")}` : t("kentico.components.mediafileselector.missingfile.title") : "", c = e => e.name + e.extension, a = (e, t) => e.name ? `${l(e, t)} - ${c(e)}` : t("kentico.components.mediafileselector.missingfile"); class o { constructor() { this.MAX_THUMBNAIL_COUNT = 12, this.MAX_LIST_COUNT = 9, this.selectedFiles = [], this.getSelectedValues = (() => this.selectedFiles && this.selectedFiles.length > 0 ? this.selectedFiles.map(e => ({ fileGuid: e.fileGuid })) : []), this.setMultiFileViewMode = (e => { this.isListMode = this.containsNonImageFile(e) }), this.containsNonImageFile = (e => e.filter(e => null === e.thumbnailUrls && e.isValid).length > 0), this.transferInvalidFlag = ((e, t) => { const i = []; return e.forEach(e => { const l = t.filter(t => t.fileGuid === e.fileGuid)[0]; l ? i.push(l) : i.push(e) }), i }), this.openDialog = (() => { const e = { libraryName: this.libraryName, maxFilesLimit: this.maxFilesLimit, allowedExtensions: this.allowedExtensions, selectedValues: this.getSelectedValues(), applyCallback: e => { const t = this.selectedFiles.filter(e => !e.isValid); return null !== (e = this.transferInvalidFlag(e, t)) && e.length > 0 ? (this.setMultiFileViewMode(e), this.selectValues(e)) : this.clear(), { closeDialog: !0 } } }; window.kentico.modalDialog.mediaFilesSelector.open(e) }), this.changeSingleFileDialog = (e => { const t = this.selectedFiles.indexOf(e), i = { libraryName: this.libraryName, maxFilesLimit: 1, allowedExtensions: this.allowedExtensions, selectedValues: [{ fileGuid: e.fileGuid }], applyCallback: i => { if (null !== i && 1 === i.length) { const l = i[0]; if (l.fileGuid === e.fileGuid) return { closeDialog: !0 }; const s = [...this.selectedFiles]; this.selectedFiles.filter(e => e.fileGuid === l.fileGuid).length > 0 ? s.splice(t, 1) : s[t] = l, this.setMultiFileViewMode(s), this.selectValues(s) } return { closeDialog: !0 } } }; window.kentico.modalDialog.mediaFilesSelector.open(i) }), this.clear = (() => this.selectValues([])), this.remove = (e => this.selectValues(this.selectedFiles.filter(t => t !== e))), this.showAllFiles = (() => this.allFilesShowed = !0), this.renderShowAllLink = (() => e("div", { class: "ktc-show-all-items-container" }, e("div", null, e("a", { onClick: this.showAllFiles }, this.getString("kentico.components.mediafileselector.showAll"))))), this.renderThumbnail = (t => e("div", { class: "ktc-selector-thumbnail", title: n(t, this.getString) }, e("div", { class: "ktc-overlay" }), e("i", { "aria-hidden": "true", title: this.getString("kentico.components.mediafileselector.changeFile"), class: "icon-rotate-double-right ktc-cms-icon-80 ktc-action-icon", onClick: () => this.changeSingleFileDialog(t) }), e("i", { "aria-hidden": "true", title: this.getString("kentico.components.mediafileselector.removeFile"), class: "icon-bin ktc-cms-icon-80 ktc-action-icon", onClick: () => this.remove(t) }), t.isValid ? e("img", { class: "ktc-thumbnail-image", src: t.thumbnailUrls.small }) : e("span", { class: "ktc-invalid-file" }, e("i", { "aria-hidden": "true", class: "icon-exclamation-triangle ktc-cms-icon-130 ktc-type-icon" }), l(t, this.getString)))), this.renderList = (t => e("li", { class: { "ktc-file-item": !0, "ktc-invalid-file": !t.isValid }, title: n(t, this.getString) }, e("i", { "aria-hidden": "true", class: `${this.getIconClassName(t)} ktc-cms-icon-80 ktc-type-icon` }), e("span", null, s(t, this.getString)), e("i", { "aria-hidden": "true", class: "icon-rotate-double-right ktc-cms-icon-80 ktc-action-icon", title: this.getString("kentico.components.mediafileselector.changeFile"), onClick: () => this.changeSingleFileDialog(t) }), e("i", { "aria-hidden": "true", class: "icon-bin ktc-cms-icon-80 ktc-action-icon", title: this.getString("kentico.components.mediafileselector.removeFile"), onClick: () => this.remove(t) }))), this.getIconClassName = (e => e.isValid ? e.thumbnailUrls ? "icon-picture" : "icon-doc" : "icon-exclamation-triangle"), this.renderEmptySelector = (() => e("div", { class: "ktc-selector-empty" }, this.getString("kentico.components.mediafileselector.empty"))), this.renderAllSelectedFiles = (() => this.selectedFiles && 0 !== this.selectedFiles.length ? this.isListMode ? this.renderNonImageFiles() : this.renderThumbnails() : this.renderEmptySelector()), this.renderNonImageFiles = (() => this.selectedFiles.length > this.MAX_LIST_COUNT && !this.allFilesShowed ? [e("ul", null, [...this.selectedFiles].slice(0, this.MAX_LIST_COUNT).map(this.renderList)), this.renderShowAllLink()] : e("ul", null, this.selectedFiles.map(this.renderList))), this.renderThumbnails = (() => this.selectedFiles.length > this.MAX_THUMBNAIL_COUNT && !this.allFilesShowed ? [[...this.selectedFiles].slice(0, this.MAX_THUMBNAIL_COUNT).map(this.renderThumbnail), this.renderShowAllLink()] : this.selectedFiles.map(this.renderThumbnail)) } componentWillLoad() { this.setMultiFileViewMode(this.selectedFiles) } render() { return e("div", { class: "ktc-mediafile-selector-component" }, e("div", { class: "ktc-form-control ktc-multi-file-box" }, this.renderAllSelectedFiles()), e("div", { class: "ktc-multi-file-buttons" }, e("button", { type: "button", class: "ktc-btn ktc-btn-default", onClick: this.openDialog }, this.getString("kentico.components.mediafileselector.select")), e("button", { type: "button", class: "ktc-btn ktc-btn-default", onClick: this.clear }, this.getString("kentico.components.mediafileselector.clearall")))) } static get is() { return "kentico-media-files-multiple-form-component" } static get properties() { return { allFilesShowed: { state: !0 }, allowedExtensions: { type: String, attr: "allowed-extensions" }, getString: { type: "Any", attr: "get-string" }, isListMode: { state: !0 }, libraryName: { type: String, attr: "library-name" }, maxFilesLimit: { type: Number, attr: "max-files-limit" }, selectedFiles: { type: "Any", attr: "selected-files" }, selectValues: { type: "Any", attr: "select-values" } } } static get style() { return "[class*=\" icon-\"],[class^=icon-]{font-family:Core-icons;display:inline-block;speak:none;font-style:normal;font-weight:400;font-variant:normal;text-transform:none;line-height:1;font-size:16px;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-image:none}[class^=icon-]:before{content:\"\\e619\"}.ktc-icon-only:before{content:none}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .icon-doc:before{content:\"\\e69f\"}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .icon-rotate-double-right:before{content:\"\\e622\"}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .icon-bin:before{content:\"\\e6d0\"}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .icon-picture:before{content:\"\\e633\"}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .icon-exclamation-triangle:before{content:\"\\e693\"}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box{height:auto;width:320px;position:relative;padding:4px;margin-bottom:8px}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail{position:relative;width:77px;height:77px;float:left}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail img.ktc-thumbnail-image{position:absolute;top:50%;left:50%;-webkit-transform:translate(-50%,-50%);transform:translate(-50%,-50%)}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail span.ktc-invalid-file{position:absolute;top:50%;left:50%;-webkit-transform:translate(-50%,-50%);transform:translate(-50%,-50%);color:#c98209;text-align:center}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail span.ktc-invalid-file i{color:#c98209;margin:0;padding-bottom:0;padding-top:0}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail .ktc-action-icon{position:absolute;cursor:pointer;visibility:hidden;top:50%;opacity:0;text-align:center;color:#403e3d;margin:0;z-index:2}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail .ktc-action-icon.icon-rotate-double-right{left:11.5px;-webkit-transform:translate(0,-50%);transform:translate(0,-50%)}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail .ktc-action-icon.icon-bin{left:65.5px;-webkit-transform:translate(-100%,-50%);transform:translate(-100%,-50%)}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail .ktc-overlay{background-color:rgba(255,255,255,.75);position:absolute;top:0;bottom:0;left:0;right:0;height:100%;width:100%;opacity:0;-webkit-transition:.5s ease;transition:.5s ease;z-index:1}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail:hover .ktc-action-icon{visibility:visible;opacity:1;-webkit-transition:.5s ease;transition:.5s ease}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-thumbnail:hover .ktc-overlay{opacity:1}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul{padding:0}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item{list-style-type:none;position:relative;padding:3px 4px 3px 0}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item .ktc-type-icon{margin:0;position:absolute;top:50%;left:0;-webkit-transform:translate(0,-50%);transform:translate(0,-50%)}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item span{margin-left:25px;width:230px;white-space:nowrap;overflow:hidden;text-overflow:ellipsis;display:inherit}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item .ktc-action-icon{position:absolute;cursor:pointer;visibility:hidden;top:50%;opacity:0;text-align:center;color:#403e3d;margin:0;z-index:2;-webkit-transform:translate(0,-50%);transform:translate(0,-50%)}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item .ktc-action-icon.icon-rotate-double-right{right:32px}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item .ktc-action-icon.icon-bin{right:5px}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item:hover{background-color:#d6d9d6;-webkit-transition:.5s ease;transition:.5s ease}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item:hover .ktc-action-icon{visibility:visible;opacity:1;-webkit-transition:.5s ease;transition:.5s ease}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item.ktc-invalid-file .ktc-type-icon,kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box ul li.ktc-file-item.ktc-invalid-file span{color:#c98209}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-selector-empty{color:#a3a2a2;line-height:77px;text-align:center}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-show-all-items-container{position:absolute;bottom:0;left:0;right:0;height:40px;background:-webkit-gradient(linear,left top,left bottom,color-stop(0,rgba(255,255,255,.05)),color-stop(50%,rgba(255,255,255,.95)),to(#fff));background:linear-gradient(to bottom,rgba(255,255,255,.05) 0,rgba(255,255,255,.95) 50%,#fff 100%)}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-multi-file-box .ktc-show-all-items-container div{text-align:center;position:absolute;bottom:2px;width:100%;z-index:1}kentico-media-files-multiple-form-component .ktc-mediafile-selector-component .ktc-multi-file-buttons{width:320px;text-align:right}" } } class r { constructor() { this.MAX_FILES_LIMIT = 1, this.shortenFileName = (() => { const e = this.element.querySelector(".ktc-label-filename"); null !== e && t(e, 3) }), this.openDialog = (() => { const e = { libraryName: this.libraryName, maxFilesLimit: this.MAX_FILES_LIMIT, allowedExtensions: this.allowedExtensions, selectedValues: this.selectedFile ? [{ fileGuid: this.selectedFile.fileGuid }] : [], applyCallback: e => { if (null !== e && 1 === e.length) { const t = e[0]; if (this.selectedFile && t.fileGuid === this.selectedFile.fileGuid) return { closeDialog: !0 }; this.selectValues([e[0]]) } else this.clear(); return { closeDialog: !0 } } }; window.kentico.modalDialog.mediaFilesSelector.open(e) }), this.clear = (() => this.selectValues([])), this.renderImageFile = (() => e("div", { class: "ktc-selector-thumbnail" }, e("img", { class: "ktc-thumbnail-image", src: this.selectedFile.thumbnailUrls.large }))), this.renderNoImageFile = (() => e("div", { class: "ktc-selector-file-icon" }, e("i", { "aria-hidden": "true", class: "icon-doc ktc-cms-icon-150" }), e("div", { class: "ktc-label-filename" }, s(this.selectedFile, this.getString)))), this.renderInvalidFile = (() => e("div", { class: "ktc-selector-file-icon ktc-invalid-file" }, e("i", { "aria-hidden": "true", class: "icon-exclamation-triangle ktc-cms-icon-150" }), e("div", { class: "ktc-label-filename" }, s(this.selectedFile, this.getString)))), this.renderBigThumbnail = (() => this.selectedFile ? this.selectedFile.isValid ? this.selectedFile.thumbnailUrls ? this.renderImageFile() : this.renderNoImageFile() : this.renderInvalidFile() : e("div", { class: "ktc-selector-empty" }, e("i", { "aria-hidden": "true", class: "icon-ban-sign ktc-cms-icon-200" }))) } componentDidLoad() { this.shortenFileName() } componentDidUpdate() { this.shortenFileName() } render() { return e("div", { class: "ktc-mediafile-selector-component" }, e("div", { class: "ktc-form-control ktc-file-box", title: n(this.selectedFile, this.getString) }, this.renderBigThumbnail(), this.selectedFile ? e("div", { class: "ktc-overlay" }, e("div", null, e("button", { type: "button", class: "ktc-btn ktc-btn-default", onClick: this.openDialog, title: "" }, this.getString("kentico.components.mediafileselector.selectdifferent")), e("span", null, this.getString("kentico.components.mediafileselector.or")), " ", e("a", { onClick: this.clear, title: "" }, this.getString("kentico.components.mediafileselector.clear")))) : e("button", { type: "button", class: "ktc-btn ktc-btn-default ktc-select-button", onClick: this.openDialog }, this.getString("kentico.components.mediafileselector.select")))) } static get is() { return "kentico-media-files-single-form-component" } static get properties() { return { allowedExtensions: { type: String, attr: "allowed-extensions" }, element: { elementRef: !0 }, getString: { type: "Any", attr: "get-string" }, libraryName: { type: String, attr: "library-name" }, selectedFile: { type: "Any", attr: "selected-file" }, selectValues: { type: "Any", attr: "select-values" } } } static get style() { return "[class*=\" icon-\"],[class^=icon-]{font-family:Core-icons;display:inline-block;speak:none;font-style:normal;font-weight:400;font-variant:normal;text-transform:none;line-height:1;font-size:16px;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-image:none}[class^=icon-]:before{content:\"\\e619\"}.ktc-icon-only:before{content:none}kentico-media-files-single-form-component .ktc-mediafile-selector-component .icon-doc:before{content:\"\\e69f\"}kentico-media-files-single-form-component .ktc-mediafile-selector-component .icon-ban-sign:before{content:\"\\e6d1\"}kentico-media-files-single-form-component .ktc-mediafile-selector-component .icon-exclamation-triangle:before{content:\"\\e693\"}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box{height:240px;width:320px;position:relative;padding:0}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box a{text-decoration:none}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-overlay{background-color:rgba(255,255,255,.75);position:absolute;top:0;bottom:0;left:0;right:0;height:100%;width:100%;opacity:0;-webkit-transition:.5s ease;transition:.5s ease;z-index:1}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box:hover .ktc-overlay{opacity:1}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-thumbnail{position:absolute;top:50%;left:50%;-webkit-transform:translate(-50%,-50%);transform:translate(-50%,-50%);text-align:center}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-thumbnail .ktc-thumbnail-image{max-height:236px;max-width:316px}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-file-icon{position:absolute;left:50%;-webkit-transform:translateX(-50%);transform:translateX(-50%);text-align:center;top:64px}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-file-icon.ktc-invalid-file .ktc-label-filename,kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-file-icon.ktc-invalid-file i{color:#c98209}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-file-icon .ktc-label-filename{text-align:center;line-height:16px;width:160px;word-wrap:break-word}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-empty{position:absolute;left:50%;-webkit-transform:translateX(-50%);transform:translateX(-50%);top:56px}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-selector-empty i{color:#a3a2a2;margin:0}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-select-button{position:absolute;left:50%;-webkit-transform:translateX(-50%);transform:translateX(-50%);top:164px}kentico-media-files-single-form-component .ktc-mediafile-selector-component .ktc-form-control.ktc-file-box .ktc-overlay div{position:absolute;left:50%;-webkit-transform:translateX(-50%);transform:translateX(-50%);top:164px;text-align:center}" } } export { i as KenticoMediaFilesFormComponent, o as KenticoMediaFilesMultipleFormComponent, r as KenticoMediaFilesSingleFormComponent };