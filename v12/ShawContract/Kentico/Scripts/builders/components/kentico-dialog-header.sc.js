/*! Built with http://stenciljs.com */
const { h: t } = window.components; import { a as e } from "./chunk-a93dedfa.js"; class a { constructor() { this.onClose = (t => { t.stopPropagation(), this.close.emit() }), this.onBackButtonClick = (t => { t.stopPropagation(), this.back.emit() }) } render() { return this.dialogHeaderEl.setAttribute("theme", this.theme), t("div", { class: `ktc-dialog-header-wrapper ktc-theme-${this.theme}` }, t("div", { class: "ktc-dialog-header" }, t("div", { class: "ktc-dialog-header-controls" }, t("a", { onClick: this.onClose }, t("i", { "aria-hidden": "true", title: this.closeTooltip, class: "icon-modal-close" }))), this.showBackButton && t("div", { class: "ktc-dialog-header-back" }, t("a", { onClick: this.onBackButtonClick }, t("i", { "aria-hidden": "true", title: this.backTooltip, class: "icon-chevron-left" }))), t("div", { class: { "ktc-dialog-header-title": !0, "ktc-dialog-header-title--displaced": this.showBackButton } }, this.headerTitle))) } static get is() { return "kentico-dialog-header" } static get encapsulation() { return "shadow" } static get properties() { return { backTooltip: { type: String, attr: "back-tooltip" }, closeTooltip: { type: String, attr: "close-tooltip" }, dialogHeaderEl: { elementRef: !0 }, headerTitle: { type: String, attr: "header-title" }, showBackButton: { type: Boolean, attr: "show-back-button" }, theme: { type: "Any", attr: "theme" } } } static get events() { return [{ name: "close", method: "close", bubbles: !0, cancelable: !0, composed: !0 }, { name: "back", method: "back", bubbles: !0, cancelable: !0, composed: !0 }] } static get style() { return "[class*=\" icon-\"][data-kentico-dialog-header], [class^=icon-][data-kentico-dialog-header]{font-family:Core-icons;display:inline-block;speak:none;font-style:normal;font-weight:400;font-variant:normal;text-transform:none;line-height:1;font-size:16px;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-image:none}[class^=icon-][data-kentico-dialog-header]:before{content:\"\\e619\"}.ktc-icon-only[data-kentico-dialog-header]:before{content:none}[data-kentico-dialog-header-host]{display:block}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]{border-bottom:1px solid #d6d9d6;height:36px}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]{width:100%}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-back[data-kentico-dialog-header]{float:left}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-back[data-kentico-dialog-header]   a[data-kentico-dialog-header]{display:table-cell}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-back[data-kentico-dialog-header]   a[data-kentico-dialog-header]   .icon-chevron-left[data-kentico-dialog-header]{cursor:pointer;color:#fff;padding:10px 8px 8px;font-size:18px}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-back[data-kentico-dialog-header]   a[data-kentico-dialog-header]   .icon-chevron-left[data-kentico-dialog-header]:before{content:\"\\e66c\"}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-title[data-kentico-dialog-header]{color:#fff;font-size:16px;line-height:36px;white-space:nowrap;overflow:hidden;text-overflow:ellipsis;padding-left:10px}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-title.ktc-dialog-header-title--displaced[data-kentico-dialog-header]{padding-left:0}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]{float:right}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]{display:table-cell}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]   i[data-kentico-dialog-header]{cursor:pointer;font-size:24px;padding:6px;-webkit-box-sizing:content-box;box-sizing:content-box}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]   i.icon-modal-close[data-kentico-dialog-header]{font-weight:700}[data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]   i.icon-modal-close[data-kentico-dialog-header]:before{content:\"\\e64a\"}[theme=widget][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]{background-color:#0f6194}[theme=widget][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]{background:#1175ae}[theme=widget][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]   i[data-kentico-dialog-header]{color:#fff}[theme=widget][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]:hover{background:rgba(255,255,255,.2)}[theme=section][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]{background-color:#262524}[theme=section][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]{background:#403e3d}[theme=section][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]   i[data-kentico-dialog-header]{color:#fff}[theme=section][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]:hover{background:rgba(255,255,255,.2)}[theme=template][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]{background-color:#a15700}[theme=template][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]{background:#c98209}[theme=template][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]   i[data-kentico-dialog-header]{color:#fff}[theme=template][data-kentico-dialog-header-host]   .ktc-dialog-header-wrapper[data-kentico-dialog-header]   .ktc-dialog-header[data-kentico-dialog-header]   .ktc-dialog-header-controls[data-kentico-dialog-header]   a[data-kentico-dialog-header]:hover{background:rgba(255,255,255,.2)}" } } export { a as KenticoDialogHeader };