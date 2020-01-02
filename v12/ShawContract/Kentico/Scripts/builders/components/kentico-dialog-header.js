/*! Built with http://stenciljs.com */
const { h: t } = window.components; import { a as e } from "./chunk-a93dedfa.js"; class a { constructor() { this.onClose = (t => { t.stopPropagation(), this.close.emit() }), this.onBackButtonClick = (t => { t.stopPropagation(), this.back.emit() }) } render() { return this.dialogHeaderEl.setAttribute("theme", this.theme), t("div", { class: `ktc-dialog-header-wrapper ktc-theme-${this.theme}` }, t("div", { class: "ktc-dialog-header" }, t("div", { class: "ktc-dialog-header-controls" }, t("a", { onClick: this.onClose }, t("i", { "aria-hidden": "true", title: this.closeTooltip, class: "icon-modal-close" }))), this.showBackButton && t("div", { class: "ktc-dialog-header-back" }, t("a", { onClick: this.onBackButtonClick }, t("i", { "aria-hidden": "true", title: this.backTooltip, class: "icon-chevron-left" }))), t("div", { class: { "ktc-dialog-header-title": !0, "ktc-dialog-header-title--displaced": this.showBackButton } }, this.headerTitle))) } static get is() { return "kentico-dialog-header" } static get encapsulation() { return "shadow" } static get properties() { return { backTooltip: { type: String, attr: "back-tooltip" }, closeTooltip: { type: String, attr: "close-tooltip" }, dialogHeaderEl: { elementRef: !0 }, headerTitle: { type: String, attr: "header-title" }, showBackButton: { type: Boolean, attr: "show-back-button" }, theme: { type: "Any", attr: "theme" } } } static get events() { return [{ name: "close", method: "close", bubbles: !0, cancelable: !0, composed: !0 }, { name: "back", method: "back", bubbles: !0, cancelable: !0, composed: !0 }] } static get style() { return "[class*=\" icon-\"],[class^=icon-]{font-family:Core-icons;display:inline-block;speak:none;font-style:normal;font-weight:400;font-variant:normal;text-transform:none;line-height:1;font-size:16px;-webkit-font-smoothing:antialiased;-moz-osx-font-smoothing:grayscale;background-image:none}[class^=icon-]:before{content:\"\\e619\"}.ktc-icon-only:before{content:none}:host{display:block}:host .ktc-dialog-header-wrapper{border-bottom:1px solid #d6d9d6;height:36px}:host .ktc-dialog-header-wrapper .ktc-dialog-header{width:100%}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-back{float:left}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-back a{display:table-cell}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-back a .icon-chevron-left{cursor:pointer;color:#fff;padding:10px 8px 8px;font-size:18px}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-back a .icon-chevron-left:before{content:\"\\e66c\"}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-title{color:#fff;font-size:16px;line-height:36px;white-space:nowrap;overflow:hidden;text-overflow:ellipsis;padding-left:10px}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-title.ktc-dialog-header-title--displaced{padding-left:0}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls{float:right}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a{display:table-cell}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a i{cursor:pointer;font-size:24px;padding:6px;-webkit-box-sizing:content-box;box-sizing:content-box}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a i.icon-modal-close{font-weight:700}:host .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a i.icon-modal-close:before{content:\"\\e64a\"}:host([theme=widget]) .ktc-dialog-header-wrapper{background-color:#0f6194}:host([theme=widget]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a{background:#1175ae}:host([theme=widget]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a i{color:#fff}:host([theme=widget]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a:hover{background:rgba(255,255,255,.2)}:host([theme=section]) .ktc-dialog-header-wrapper{background-color:#262524}:host([theme=section]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a{background:#403e3d}:host([theme=section]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a i{color:#fff}:host([theme=section]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a:hover{background:rgba(255,255,255,.2)}:host([theme=template]) .ktc-dialog-header-wrapper{background-color:#a15700}:host([theme=template]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a{background:#c98209}:host([theme=template]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a i{color:#fff}:host([theme=template]) .ktc-dialog-header-wrapper .ktc-dialog-header .ktc-dialog-header-controls a:hover{background:rgba(255,255,255,.2)}" } } export { a as KenticoDialogHeader };