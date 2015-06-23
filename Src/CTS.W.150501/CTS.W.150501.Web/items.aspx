<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true"
    CodeBehind="items.aspx.cs" Inherits="CTS.W._150501.Web.items" %>

<%@ Import Namespace="CTS.Web.Com.Domain.Helper" %>
<%@ Import Namespace="CTS.Com.Domain.Model" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="contentMain" runat="server">
    <div class="wr-content-top">
        <!-- effect product -->
        <script type="text/javascript">
            jQuery.noConflict();
            var resizeTimer = null;
            jQuery(window).bind('resize', function () {
                if (resizeTimer) clearTimeout(resizeTimer);
                resizeTimer = setTimeout("tz_init(" + "320)", 100);
            });

            function tz_init(defaultwidth) {
                var contentWidth = jQuery('#content').width();
                var columnWidth = defaultwidth;
                var curColCount = 0;
                var maxColCount = 0;
                var newColCount = 0;
                var newColWidth = 0;
                var featureColWidth = 0;

                curColCount = Math.floor(contentWidth / columnWidth);
                maxColCount = curColCount + 1;
                if ((maxColCount - (contentWidth / columnWidth)) > ((contentWidth / columnWidth) - curColCount)) {
                    newColCount = curColCount;
                }
                else {
                    newColCount = maxColCount;
                }
                newColWidth = contentWidth;
                featureColWidth = contentWidth;

                if (newColCount > 1) {
                    newColWidth = Math.floor(contentWidth / newColCount);
                    featureColWidth = newColWidth;
                }
                jQuery('.element').width(newColWidth);
                jQuery('.tz_item').each(function () {
                    jQuery(this).find('img').first().attr('width', '100%');
                });
                var $container = jQuery('#portfolio');
                $container.imagesLoaded(function () {
                    $container.isotope({
                        masonry: {
                            columnWidth: newColWidth
                        }
                    });
                });

            }
        </script>
        <div class="clear">
        </div>
        <div id="content">
            <asp:Repeater ID="rptItems" runat="server">
                <HeaderTemplate>
                    <ul id="portfolio" class="wr-product hieuung-scroll">
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="element tz_item">
                        <div class="inner">
                            <a href='<%# "/" + WebContextHelper.LocaleCd + "/dich-vu/chi-tiet/" + ((HashMap)Container.DataItem)["LinkName"] %>'
                                title='<%# ((HashMap)Container.DataItem)["ItemName"] %>'>
                                <img src='<%# "/ImageResize.ashx?w=420&h=320&bgcolor=FFF&path=" + ((HashMap)Container.DataItem)["ItemImage"] + "_normal" %>' />
                            </a>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    <div id="tz_append">
                    </div>
                    <div id="loadaj" style="display: none;">
                        <a href='/ScrollPagerHandler.ashx?lang=<%=WebContextHelper.LocaleCd%>&c=<%=HdcatCd.Value%>&l=<%=hdLimit.Value %>&p=2'></a>
                    </div>
                    
                    </session>
                </FooterTemplate>
            </asp:Repeater>
            <!-- load scroll product -->
            <script type="text/javascript">
                var tz = jQuery.noConflict();
                tz(function () {
                    var tzpage = 1;
                    var $container = tz('#content');
                    $container.imagesLoaded(function () {
                        $container.isotope({
                            itemSelector: '.element'
                        });
                    });
                    tz('#tz_append').css({ 'border': 0, 'background': 'none' });
                    $container.infinitescroll({
                            navSelector: '#loadaj a',    // selector for the paged navigation
                            nextSelector: '#loadaj a:first',  // selector for the NEXT link (to page 2)
                            itemSelector: '.element',     // selector for all items you'll retrieve
                            errorCallback: function () {
                                tz('#tz_append').removeAttr('style').html('<a class="tzNomore"></a>');
                                tz('#tz_append a').addClass('tzNomore');
                            },
                            loading: {
                                finishedMsg: '',
                                img: '/res/cln/images/loading.gif',
                                selector: '#tz_append'
                            }
                        },
                        // call Isotope as a callback
                        function (newElements) {
                            var $newElems = tz(newElements).css({ opacity: 0 });
                            // ensure that images load before adding to masonry layout
                            $newElems.imagesLoaded(function () {
                                // show elems now they're ready
                                $newElems.animate({ opacity: 1 });
                                tz_init(320);
                                // trigger scroll again
                                $container.isotope('appended', $newElems);
                                tzpage++;
                                tz.post('/ScrollPagerHandler.ashx?lang=<%=WebContextHelper.LocaleCd %>&c=<%=HdcatCd.Value %>&l=<%=hdLimit.Value %>&p=' + tzpage, function (data) {
                                    if (data != null) {
                                        tztag = tz(data);
                                        tz('#portfolio').append(tztag);
                                    }
                                });
                            });
                        }
                    );
                });
            </script>
            <!-- effect product -->
            <script type="text/javascript">

                var tz = jQuery.noConflict();
                var resizeTimer = null;

                jQuery(window).bind('resize', function () {
                    if (resizeTimer) clearTimeout(resizeTimer);
                    resizeTimer = setTimeout("tz_init(" + "320)", 100);
                });

                var $container = tz('#content');
                $container.imagesLoaded(function () {
                    $container.isotope({
                        itemSelector: '.element',
                        layoutMode: 'masonry'
                    });
                    tz_init(320);
                });
            </script>
        </div>
    </div>
    <asp:HiddenField ID="HdcatCd" runat="server" />
    <asp:HiddenField ID="hdTotal" runat="server" />
    <asp:HiddenField ID="hdLimit" runat="server" />
    <input type="hidden" value="2" id="pageIndex" />
    <input type="hidden" value="false" id="hdProcessing" />
</asp:Content>
