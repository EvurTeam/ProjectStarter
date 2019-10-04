using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStarter
{
    public static class TextTemplates
    {
        public static readonly string HtmlPageSource =
@"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <meta http-equiv='X-UA-Compatible' content='ie=edge'>
    $STYLES$
    $SCRIPTS$
    <title>$TITLE$</title>
</head>
<body>
    $HEADER$
    $MAIN$
    $FOOTER$
</body>
</html>";

        public static readonly string PhpPageSource =
@"<? 
    header('Content-Type: text/html; charset=utf-8');
?>
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <meta http-equiv='X-UA-Compatible' content='ie=edge'>
    $STYLES$
    $SCRIPTS$
    <title>$TITLE$</title>
</head>
<body>
    $HEADER$
    $MAIN$
    $FOOTER$
</body>
</html>";

        public static readonly string Lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static readonly string Header =
@"<header>
    $LOREM$
    </header>";

        public static readonly string Main =
@"<main>
    $LOREM$
    </main>";

        public static readonly string Footer =
@"<footer>
    $LOREM$
    </footer>";

    }
}
