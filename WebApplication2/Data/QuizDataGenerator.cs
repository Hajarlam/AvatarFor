using System;
using System.Collections.Generic;
using System.Linq;
using LMS.Data;

namespace LMS.Data
{
    public static class QuizDataGenerator
    {
        private class QuestionTemplate
        {
            public string Text { get; set; }
            public string[] Options { get; set; }
            public int CorrectIndex { get; set; }
        }

        public static void Seed(ApplicationDbContext context)
        {
            // Liste des catégories et leurs templates de questions
            var templates = new Dictionary<string, List<QuestionTemplate>>
            {
                {
                    "HTML/CSS", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Que signifie HTML ?", Options = new[] { "Hyper Text Markup Language", "Home Tool Markup Language", "Hyperlinks and Text Markup Language", "Hyper Tool Multi Language" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle balise est utilisée pour créer un lien hypertexte ?", Options = new[] { "<a>", "<link>", "<href>", "<line>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel attribut définit le chemin d'une image ?", Options = new[] { "src", "href", "link", "path" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle propriété CSS change la couleur du texte ?", Options = new[] { "color", "font-color", "text-color", "foreground" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment commente-t-on du code HTML ?", Options = new[] { "<!-- Commentaire -->", "// Commentaire", "/* Commentaire */", "' Commentaire" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle balise représente le contenu principal autonome en HTML5 ?", Options = new[] { "<main>", "<section>", "<body>", "<content>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la valeur par défaut de la propriété CSS position ?", Options = new[] { "static", "relative", "absolute", "fixed" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait box-sizing: border-box ?", Options = new[] { "Inclut le padding et les bordures dans la largeur et hauteur totales", "Exclut les bordures du modèle de boîte", "Force le conteneur à occuper tout l'écran", "Supprime les marges" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment cibler un élément avec l'ID 'test' en CSS ?", Options = new[] { "#test", ".test", "test", "*test" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel élément HTML5 sert à insérer une figure et sa légende ?", Options = new[] { "<figure>", "<picture>", "<aside>", "<details>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle propriété CSS définit l'espacement externe ?", Options = new[] { "margin", "padding", "border-spacing", "gap" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que signifie CSS ?", Options = new[] { "Cascading Style Sheets", "Creative Style System", "Computer Style Sheets", "Colorful Style Sheets" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle balise insère un retour à la ligne ?", Options = new[] { "<br>", "<lb>", "<break>", "<line>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment ouvrir un lien dans un nouvel onglet ?", Options = new[] { "target='_blank'", "target='new'", "href='_blank'", "window='new'" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle balise déclare une liste ordonnée ?", Options = new[] { "<ol>", "<ul>", "<li>", "<list>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel sélecteur cible directement un enfant immédiat en CSS ?", Options = new[] { "parent > enfant", "parent enfant", "parent + enfant", "parent ~ enfant" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait la propriété z-index ?", Options = new[] { "Spécifie l'ordre d'empilement vertical", "Ajuste le zoom d'un élément", "Définit le nombre de colonnes", "Gère les ombres" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment définir une grille CSS à 3 colonnes égales ?", Options = new[] { "grid-template-columns: repeat(3, 1fr);", "grid-columns: 33% 33% 33%;", "display: flex-columns(3);", "grid-template: 1fr 1fr 1fr;" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle propriété CSS spécifie le débordement de contenu ?", Options = new[] { "overflow", "clip", "display", "word-wrap" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la valeur de position pour fixer un élément par rapport au viewport ?", Options = new[] { "fixed", "absolute", "sticky", "relative" }, CorrectIndex = 0 }
                    }
                },
                {
                    "Python", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quel symbole est utilisé pour les commentaires en Python ?", Options = new[] { "#", "//", "/*", "--" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction affiche un texte dans la console ?", Options = new[] { "print()", "echo()", "console.log()", "system.out.print()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment crée-t-on une liste en Python ?", Options = new[] { "ma_liste = [1, 2, 3]", "ma_liste = {1, 2, 3}", "ma_liste = (1, 2, 3)", "ma_liste = list(1, 2, 3)" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle structure de contrôle est correcte ?", Options = new[] { "if x > 5:", "if (x > 5) { }", "if x > 5 then", "if x > 5 begin" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel est le résultat de 3 ** 2 en Python ?", Options = new[] { "9", "6", "5", "27" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer une fonction en Python ?", Options = new[] { "def ma_fonction():", "function ma_fonction()", "void ma_fonction():", "create ma_fonction():" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel type de données est non modifiable (immutable) ?", Options = new[] { "tuple", "list", "dict", "set" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la sortie de len({'a': 1, 'b': 2}) ?", Options = new[] { "2", "4", "1", "0" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment ajouter un élément à la fin d'une liste ?", Options = new[] { "append()", "add()", "push()", "insert()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment récupérer la valeur d'une clé 'x' d'un dictionnaire 'd' en évitant les erreurs ?", Options = new[] { "d.get('x')", "d['x']", "d.find('x')", "d.fetch('x')" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la sortie de bool(0) et bool([]) ?", Options = new[] { "False, False", "True, False", "False, True", "True, True" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment importer un module 'math' en Python ?", Options = new[] { "import math", "require('math')", "using math", "include math" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait la fonction range(1, 5) ?", Options = new[] { "Génère les nombres de 1 à 4", "Génère les nombres de 1 à 5", "Génère 5 nombres au hasard", "Crée une liste de taille 5" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment attraper les exceptions en Python ?", Options = new[] { "try ... except", "try ... catch", "try ... error", "begin ... rescue" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Qu'est-ce qu'un décorateur en Python ?", Options = new[] { "Une fonction qui modifie le comportement d'une autre fonction", "Une classe de fenêtres graphiques", "Un module de chaînes de caractères", "Une méthode de destruction" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment créer un générateur en Python ?", Options = new[] { "En utilisant le mot-clé yield dans une fonction", "En héritant de Generator", "En appelant generator()", "En utilisant loop" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la fonction du constructeur dans une classe ?", Options = new[] { "__init__", "__new__", "construct", "init" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé lève une exception manuellement ?", Options = new[] { "raise", "throw", "except", "trigger" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que produit l'expression: [x * 2 for x in range(3)] ?", Options = new[] { "[0, 2, 4]", "[2, 4, 6]", "[0, 1, 2]", "[0, 4, 8]" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment copier superficiellement (shallow copy) une liste 'lst' ?", Options = new[] { "lst.copy() ou lst[:]", "copy.deepcopy(lst)", "lst", "new list(lst)" }, CorrectIndex = 0 }
                    }
                },
                {
                    "Java", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quelle est l'extension de fichier du code source Java ?", Options = new[] { ".java", ".class", ".jar", ".js" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode est le point d'entrée d'un programme Java ?", Options = new[] { "public static void main(String[] args)", "public void main(String[] args)", "public static main()", "void start()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclare-t-on une variable entière en Java ?", Options = new[] { "int x = 5;", "var x : int = 5;", "integer x = 5;", "x = 5;" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle classe est utilisée pour saisir du texte dans la console ?", Options = new[] { "Scanner", "System.in", "InputReader", "BufferedReader" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé empêche une classe d'être héritée ?", Options = new[] { "final", "const", "abstract", "private" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclare-t-on qu'une classe 'A' hérite d'une classe 'B' ?", Options = new[] { "class A extends B", "class A implements B", "class A : B", "class A inherits B" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la valeur par défaut d'une variable de type référence d'objet ?", Options = new[] { "null", "0", "false", "undefined" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé appelle le constructeur de la superclasse ?", Options = new[] { "super", "parent", "this", "base" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer un tableau d'entiers de taille 5 en Java ?", Options = new[] { "int[] tab = new int[5];", "int tab = new int(5);", "int tab[5] = new int[];", "int[] tab = [5];" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel modificateur rend un membre visible uniquement dans sa propre classe ?", Options = new[] { "private", "public", "protected", "default" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode compare le contenu de deux chaînes String ?", Options = new[] { "str1.equals(str2)", "str1 == str2", "str1.compare(str2)", "str1.match(str2)" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé implémente une interface ?", Options = new[] { "implements", "extends", "implements interface", "using" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel type de données n'est pas primitif ?", Options = new[] { "String", "int", "boolean", "double" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment lever manuellement une exception ?", Options = new[] { "throw new Exception();", "throws new Exception();", "raise new Exception();", "throw Exception;" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Qu'est-ce que le Garbage Collector ?", Options = new[] { "Un thread qui libère la mémoire des objets non référencés", "Un débogueur", "Un nettoyeur de cache", "Une méthode de fermeture" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la différence entre Checked et Unchecked exceptions ?", Options = new[] { "Les Checked doivent être obligatoirement traitées à la compilation", "Les Checked se passent uniquement sur le serveur", "Les Unchecked arrêtent la JVM", "Aucune différence" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait le mot-clé 'volatile' ?", Options = new[] { "Garantit la lecture/écriture en mémoire principale directement", "Empêche la sérialisation", "Sécurise une méthode", "Permet l'accès privé" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle interface permet le multithreading ?", Options = new[] { "Runnable", "Thread", "Executor", "Process" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la superclasse racine de tout en Java ?", Options = new[] { "java.lang.Object", "java.lang.Class", "java.lang.Root", "Base" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé permet de synchroniser l'accès à un bloc de code ?", Options = new[] { "synchronized", "lock", "secure", "atomic" }, CorrectIndex = 0 }
                    }
                },
                {
                    "JavaScript", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quelle balise HTML insère du JavaScript ?", Options = new[] { "<script>", "<javascript>", "<js>", "<scripting>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclare-t-on une constante en ES6 ?", Options = new[] { "const", "let", "var", "fixed" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel est le résultat de typeof 'test' ?", Options = new[] { "\"string\"", "\"String\"", "\"text\"", "undefined" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode affiche un message d'alerte ?", Options = new[] { "alert()", "msg()", "popup()", "console.log()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment écrire une fonction fléchée simple ?", Options = new[] { "() => {}", "() -> {}", "function => {}", "=> {}" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode sélectionne un élément HTML par son ID ?", Options = new[] { "document.getElementById()", "document.findId()", "document.getElement()", "document.query()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode transforme un tableau en appliquant une fonction sur chacun ?", Options = new[] { "map()", "forEach()", "filter()", "reduce()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel opérateur compare à la fois la valeur et le type ?", Options = new[] { "===", "==", "=", "equals" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel est le résultat de [1, 2] + [3, 4] ?", Options = new[] { "\"1,23,4\"", "[1,2,3,4]", "\"1,2,3,4\"", "NaN" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment créer une instance de Promise ?", Options = new[] { "new Promise((resolve, reject) => {})", "Promise.create()", "new Promise()", "Promise.resolve()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la sortie de console.log(3 + \"3\") ?", Options = new[] { "\"33\"", "6", "\"6\"", "NaN" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment attacher un écouteur d'événement ?", Options = new[] { "element.addEventListener()", "element.attachEvent()", "element.onclick()", "element.listen()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé attend la résolution d'une promesse ?", Options = new[] { "await", "wait", "promise", "async" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode convertit un objet en chaîne JSON ?", Options = new[] { "JSON.stringify()", "JSON.parse()", "toJSON()", "toString()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la sortie de typeof null ?", Options = new[] { "\"object\"", "\"null\"", "\"undefined\"", "\"value\"" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Qu'est-ce qu'une closure en JavaScript ?", Options = new[] { "Une fonction qui se souvient de sa portée lexicale parente", "Une balise de fermeture HTML", "Un bloqueur de scripts", "La destruction automatique de variables" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Qu'est-ce que le hoisting ?", Options = new[] { "La remontée des déclarations au sommet de leur portée", "L'import de modules à chaud", "Le décalage graphique", "Le chargement de scripts" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode appelle une fonction en passant la valeur de 'this' et un tableau d'arguments ?", Options = new[] { "apply()", "call()", "bind()", "execute()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel est le résultat de console.log(0.1 + 0.2 === 0.3) ?", Options = new[] { "False (du aux approximations binaires)", "True", "NaN", "undefined" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment annuler la propagation d'un événement ?", Options = new[] { "event.stopPropagation()", "event.preventDefault()", "event.cancel()", "return false;" }, CorrectIndex = 0 }
                    }
                },
                {
                    "React", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Qu'est-ce que JSX ?", Options = new[] { "Une extension de syntaxe XML/HTML pour JavaScript", "Un nouveau langage de programmation", "Un outil de compression CSS", "Une base de données moderne" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook gère l'état d'un composant ?", Options = new[] { "useState", "useEffect", "useContext", "useReducer" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook gère les effets secondaires ?", Options = new[] { "useEffect", "useState", "useRef", "useCallback" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment passer des données du parent à l'enfant ?", Options = new[] { "props", "state", "context", "params" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel élément sert de conteneur vide sans ajouter de balise au DOM ?", Options = new[] { "Fragment (<></>)", "<div>", "<container>", "<section>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook retourne une référence mutable ?", Options = new[] { "useRef", "useMemo", "useCallback", "useState" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook mémoïse une fonction ?", Options = new[] { "useCallback", "useMemo", "useRef", "useEffect" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook mémoïse une valeur calculée ?", Options = new[] { "useMemo", "useCallback", "useRef", "useState" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment forcer le rendu d'un composant ?", Options = new[] { "Mettre à jour son état", "Appeler render()", "Rafraîchir la page", "Modifier une variable locale" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction crée un contexte React ?", Options = new[] { "createContext", "useContext", "new Context()", "getContext" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle propriété est obligatoire lors du rendu d'une liste ?", Options = new[] { "key", "id", "index", "ref" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Qu'est-ce que le Virtual DOM ?", Options = new[] { "Une représentation en mémoire du DOM réel synchronisée", "Un DOM pour la VR", "Une version allégée du DOM réel", "Une copie temporaire" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "React est-il un framework ou une bibliothèque ?", Options = new[] { "Une bibliothèque", "Un framework complet", "Un compilateur", "Un moteur de rendu" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook accède au contexte ?", Options = new[] { "useContext", "createContext", "useReducer", "useRef" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment mettre à jour l'état 'count' via 'setCount' ?", Options = new[] { "setCount(count + 1)", "count = count + 1", "setCount = count + 1", "set(count + 1)" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook gère les états complexes avec un reducer ?", Options = new[] { "useReducer", "useState", "useMemo", "useContext" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment appelle-t-on les composants écrits sous forme de fonctions ?", Options = new[] { "Composants fonctionnels", "Composants de classe", "Composants virtuels", "Hooks" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel est le rôle du rendu conditionnel ?", Options = new[] { "Afficher des éléments selon des conditions logiques", "Optimiser le chargement", "Éviter les bugs de style", "Calculer des valeurs" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande crée un projet React avec Vite ?", Options = new[] { "npm create vite@latest", "npx create-react-app", "npm new react-app", "npm install react" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel Hook permet de nettoyer un effet secondaire ?", Options = new[] { "La fonction retournée par useEffect", "useState", "useLayoutEffect", "useCleanup" }, CorrectIndex = 0 }
                    }
                },
                {
                    "Laravel", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quel est le moteur de template par défaut de Laravel ?", Options = new[] { "Blade", "Twig", "Smarty", "Mustache" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment s'appelle l'ORM de Laravel ?", Options = new[] { "Eloquent", "Doctrine", "Hibernate", "ActiveRecord" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande CLI gère la création de fichiers et la base de données ?", Options = new[] { "Artisan", "Composer", "NPM", "Docker" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment générer un nouveau contrôleur ?", Options = new[] { "php artisan make:controller", "composer make:controller", "php make controller", "artisan create:controller" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment définir une route GET ?", Options = new[] { "Route::get()", "Route::post()", "Router::get()", "Route::define()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment appelle-t-on les fichiers structurant la base de données ?", Options = new[] { "Migrations", "Seeds", "Schemas", "Models" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel outil gère l'injection de dépendances ?", Options = new[] { "Service Container", "Eloquent", "Artisan", "Service Provider" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel fichier stocke les variables d'environnement ?", Options = new[] { ".env", "config.json", "env.php", "environment.xml" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel middleware protège contre les attaques CSRF ?", Options = new[] { "VerifyCsrfToken", "Authenticate", "EncryptCookies", "RedirectIfAuthenticated" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande exécute les migrations ?", Options = new[] { "php artisan migrate", "php migrate", "php artisan db:migrate", "artisan migrate" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel répertoire contient les routes de l'application ?", Options = new[] { "routes/web.php", "config/routes.php", "app/routes.php", "src/routes.php" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle relation Eloquent définit un lien un-à-plusieurs ?", Options = new[] { "hasMany", "belongsTo", "hasOne", "belongsToMany" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle relation Eloquent définit l'appartenance inverse ?", Options = new[] { "belongsTo", "hasMany", "hasOne", "belongsToMany" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel outil génère de fausses données de test ?", Options = new[] { "Factories / Seeders", "Migrations", "Controllers", "Models" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment récupérer toutes les lignes d'un modèle 'User' ?", Options = new[] { "User::all()", "User::get()", "User::find()", "User::select()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel middleware restreint l'accès aux connectés ?", Options = new[] { "auth", "guest", "verified", "csrf" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle méthode redirige vers une autre page ?", Options = new[] { "redirect()", "back()", "to()", "go()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment nomme-t-on le gestionnaire de paquets PHP ?", Options = new[] { "Composer", "NPM", "NuGet", "Pip" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait la commande 'php artisan queue:work' ?", Options = new[] { "Démarre un worker pour traiter les tâches en arrière-plan", "Lance le serveur local", "Exécute les tests", "Optimise le cache" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment s'appelle l'outil de validation de requêtes ?", Options = new[] { "Form Request", "Validator", "Request Validation", "Form Validation" }, CorrectIndex = 0 }
                    }
                },
                {
                    "PHP", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Par quel symbole commencent toutes les variables en PHP ?", Options = new[] { "$", "@", "#", "%" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la fonction pour afficher du texte ?", Options = new[] { "echo", "print_text", "console.log", "write" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment démarrer une session PHP ?", Options = new[] { "session_start()", "start_session()", "session()", "init_session()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle superglobale contient les variables de formulaire POST ?", Options = new[] { "$_POST", "$POST", "$_GET", "$_REQUEST" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle superglobale contient les variables d'URL (GET) ?", Options = new[] { "$_GET", "$GET", "$_POST", "$_URL" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction vérifie si une variable est définie et non nulle ?", Options = new[] { "isset()", "empty()", "defined()", "is_null()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel opérateur concatène deux chaînes en PHP ?", Options = new[] { ".", "+", "&", "concat" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction inclut un fichier et lève une erreur fatale s'il manque ?", Options = new[] { "require", "include", "import", "require_once" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle extension PHP fournit une couche d'abstraction d'accès aux bases de données ?", Options = new[] { "PDO", "MySQLi", "SQLite", "PGSQL" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment ajouter un élément à la fin d'un tableau ?", Options = new[] { "$arr[] = $val", "array_push($arr, $val)", "$arr.push($val)", "append($arr, $val)" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction convertit un tableau en chaîne JSON ?", Options = new[] { "json_encode()", "json_decode()", "json_stringify()", "toJSON()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction compte le nombre d'éléments d'un tableau ?", Options = new[] { "count()", "size()", "length()", "array_size()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer un constructeur dans une classe ?", Options = new[] { "__construct", "construct", "new", "class_name" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction détruit toutes les données de session ?", Options = new[] { "session_destroy()", "session_unset()", "session_end()", "clear_session()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle superglobale contient les cookies ?", Options = new[] { "$_COOKIE", "$COOKIE", "$_SESSION", "$_SERVER" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle superglobale contient les informations du serveur ?", Options = new[] { "$_SERVER", "$SERVER", "$_ENV", "$_REQUEST" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction détruit/supprime une variable ?", Options = new[] { "unset()", "delete()", "destroy()", "remove()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer une constante en PHP ?", Options = new[] { "define() ou const", "const", "static", "let" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction vérifie si une variable est un tableau ?", Options = new[] { "is_array()", "array_check()", "type_of()", "is_table()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel opérateur compare l'égalité stricte (valeur et type) en PHP ?", Options = new[] { "===", "==", "equals", "is" }, CorrectIndex = 0 }
                    }
                },
                {
                    ".NET", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quel langage est principalement utilisé avec .NET ?", Options = new[] { "C#", "VB.NET", "F#", "C++" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Qu'est-ce que le CLR dans .NET ?", Options = new[] { "Le moteur d'exécution (Common Language Runtime)", "La bibliothèque de classes", "Le compilateur", "Le serveur web" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel ORM est utilisé par défaut dans l'écosystème .NET ?", Options = new[] { "Entity Framework Core", "Dapper", "NHibernate", "ADO.NET" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel type de projet sert de base pour les API Web et applications Web MVC ?", Options = new[] { "ASP.NET Core", "WPF", "Windows Forms", "Console App" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment injecter un service avec une durée de vie unique par requête HTTP ?", Options = new[] { "AddScoped", "AddTransient", "AddSingleton", "AddRequest" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment injecter un service unique pour toute la durée de vie de l'application ?", Options = new[] { "AddSingleton", "AddScoped", "AddTransient", "AddStatic" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment injecter un service recréé à chaque demande ?", Options = new[] { "AddTransient", "AddScoped", "AddSingleton", "AddInstance" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel fichier stocke la configuration JSON de l'application ?", Options = new[] { "appsettings.json", "web.config", "settings.xml", "config.env" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive de routage définit l'URI des contrôleurs d'API ?", Options = new[] { "[Route]", "[HttpGet]", "[Controller]", "[Endpoint]" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel outil CLI compile le projet .NET ?", Options = new[] { "dotnet build", "dotnet compile", "dotnet run", "dotnet make" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment démarrer le projet localement en ligne de commande ?", Options = new[] { "dotnet run", "dotnet start", "dotnet go", "dotnet play" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel package gère le cryptage BCrypt ?", Options = new[] { "BCrypt.Net-Next", "Cryptography", "Security", "BCrypt" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé définit une méthode asynchrone ?", Options = new[] { "async", "await", "task", "promise" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé attend la fin d'une tâche asynchrone ?", Options = new[] { "await", "async", "wait", "task" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle classe générique encapsule une tâche asynchrone avec retour ?", Options = new[] { "Task<T>", "ValueTask", "AsyncResult", "Future<T>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel répertoire contient les fichiers statiques (css, js, images) ?", Options = new[] { "wwwroot", "dist", "public", "assets" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle classe configure le pipeline de requêtes HTTP dans Program.cs ?", Options = new[] { "WebApplication", "WebApplicationBuilder", "AppBuilder", "Startup" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive importe des espaces de noms ?", Options = new[] { "using", "import", "include", "namespace" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé déclare des variables au type implicite ?", Options = new[] { "var", "dynamic", "let", "auto" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment nomme-t-on le gestionnaire de paquets officiel de .NET ?", Options = new[] { "NuGet", "Composer", "NPM", "Pip" }, CorrectIndex = 0 }
                    }
                },
                {
                    "TypeScript", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Qu'est-ce que TypeScript ?", Options = new[] { "Un sur-ensemble typé de JavaScript qui compile en JS classique", "Un nouveau framework web", "Un moteur de base de données", "Une bibliothèque de style CSS" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer une variable chaîne typée en TS ?", Options = new[] { "let str: string = 'hello';", "let str string = 'hello';", "string str = 'hello';", "let str = 'hello' as string;" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel type représente explicitement l'absence de valeur retournée ?", Options = new[] { "void", "null", "undefined", "never" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel type permet de contourner les vérifications de type en acceptant n'importe quelle valeur ?", Options = new[] { "any", "unknown", "never", "all" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment définir la structure de forme d'un objet en TypeScript ?", Options = new[] { "interface ou type", "struct", "class", "model" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé définit un ensemble de constantes nommées ?", Options = new[] { "enum", "consts", "list", "array" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel symbole marque un attribut ou paramètre comme étant optionnel ?", Options = new[] { "?", "!", "*", "&" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer une union de types (string ou number) ?", Options = new[] { "string | number", "string & number", "string || number", "string or number" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel modificateur d'attribut de classe restreint l'accès uniquement à la classe et ses sous-classes ?", Options = new[] { "protected", "private", "public", "readonly" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait l'opérateur non-null assertion '!' ?", Options = new[] { "Indique au compilateur que la variable n'est ni null ni undefined", "Inverse la valeur logique", "Lève une exception si null", "Déclare une variable globale" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande CLI crée un fichier tsconfig.json initial ?", Options = new[] { "tsc --init", "ts-init", "typescript init", "npm init ts" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment déclarer un tableau générique de nombres ?", Options = new[] { "Array<number> ou number[]", "number[generic]", "List<number>", "int[]" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé empêche la modification d'un attribut de classe après initialisation ?", Options = new[] { "readonly", "const", "private", "locked" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel symbole est utilisé pour définir des fonctions ou classes génériques ?", Options = new[] { "<T>", "[T]", "(T)", "{T}" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la principale différence entre 'type' et 'interface' ?", Options = new[] { "Les interfaces peuvent être étendues par fusion déclarative multiple", "Les types compilent plus vite", "Les interfaces n'existent pas en JS", "Il n'y en a aucune" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Que fait l'opérateur de coalescence des nuls '??' ?", Options = new[] { "Renvoie l'opérande de droite si celle de gauche est null/undefined", "Compare deux valeurs strictement", "Concatène deux chaînes", "Compare les adresses mémoire" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est la valeur numérique par défaut du premier élément d'une enum sans affectation ?", Options = new[] { "0", "1", "-1", "null" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé est utilisé pour créer des gardes de types (Type Guards) ?", Options = new[] { "is", "typeof", "instanceof", "check" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel type représente des valeurs de retour qui n'arrivent jamais (boucle infinie ou erreur) ?", Options = new[] { "never", "void", "null", "unknown" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle syntaxe force une assertion de type en TypeScript ?", Options = new[] { "variable as Type", "Type(variable)", "(Type)variable", "typeof variable" }, CorrectIndex = 0 }
                    }
                },
                {
                    "Vue.js", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quelle directive lie dynamiquement un attribut HTML en Vue.js ?", Options = new[] { "v-bind ou :", "v-model", "v-link", "v-set" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive gère la liaison de données bidirectionnelle (two-way binding) ?", Options = new[] { "v-model", "v-bind", "v-on", "v-data" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive gère le rendu conditionnel en insérant/retirant l'élément du DOM ?", Options = new[] { "v-if", "v-show", "v-display", "v-when" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive masque un élément via la propriété CSS display: none sans le retirer du DOM ?", Options = new[] { "v-show", "v-if", "v-hide", "v-invisible" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive écoute les événements du DOM ?", Options = new[] { "v-on ou @", "v-bind", "v-event", "v-click" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Dans l'API de Composition (Vue 3), quelle fonction déclare un état réactif pour les primitives ?", Options = new[] { "ref()", "reactive()", "state()", "createRef()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction déclare un état réactif pour un objet ?", Options = new[] { "reactive()", "ref()", "computed()", "watch()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel hook du cycle de vie s'exécute après le montage du composant dans le DOM ?", Options = new[] { "onMounted", "onCreated", "onUpdated", "onBeforeMount" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle balise sert de conteneur d'insertion pour le contenu dynamique transmis par le parent ?", Options = new[] { "<slot>", "<content>", "<portal>", "<template>" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction crée une valeur réactive calculée et mise en cache ?", Options = new[] { "computed()", "watch()", "ref()", "reactive()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction observe et réagit aux changements d'un état réactif ?", Options = new[] { "watch()", "computed()", "reactive()", "ref()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle directive boucle sur un tableau de données ?", Options = new[] { "v-for", "v-repeat", "v-loop", "v-each" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel attribut est fortement requis lors de l'utilisation de v-for pour le tracking du DOM ?", Options = new[] { "key", "id", "index", "ref" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Comment émettre un événement personnalisé d'un composant enfant vers son parent ?", Options = new[] { "emit()", "trigger()", "$dispatch()", "send()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mécanisme natif permet de transmettre des données en profondeur sans prop-drilling ?", Options = new[] { "Provide / Inject", "Vuex", "Pinia", "Props" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel est le gestionnaire d'état global recommandé pour Vue 3 ?", Options = new[] { "Pinia", "Vuex", "Redux", "MobX" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel hook s'exécute juste avant le démontage du composant ?", Options = new[] { "onBeforeUnmount", "onUnmounted", "onDestroyed", "onBeforeDestroy" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel attribut dans la balise style limite le CSS à ce seul composant ?", Options = new[] { "scoped", "local", "private", "restricted" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle est l'extension des fichiers de composants monofichiers (SFC) de Vue ?", Options = new[] { ".vue", ".js", ".html", ".sfc" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel attribut ajouté à <script> active l'API de Composition simplifiée ?", Options = new[] { "setup", "composition", "reactive", "modern" }, CorrectIndex = 0 }
                    }
                },
                {
                    "SQL", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Quelle clause filtre les résultats d'une requête SELECT ?", Options = new[] { "WHERE", "HAVING", "GROUP BY", "ORDER BY" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle clause trie les lignes d'une requête ?", Options = new[] { "ORDER BY", "SORT BY", "GROUP BY", "Tri" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle clause regroupe les résultats par valeur identique de colonne ?", Options = new[] { "GROUP BY", "WHERE", "ORDER BY", "HAVING" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle clause filtre les groupes de fonctions d'agrégation formés par GROUP BY ?", Options = new[] { "HAVING", "WHERE", "FILTER", "GROUP WHERE" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle jointure retourne les lignes uniquement s'il y a correspondance dans les deux tables ?", Options = new[] { "INNER JOIN", "LEFT JOIN", "RIGHT JOIN", "FULL JOIN" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle jointure retourne toutes les lignes de la table gauche, complétée par des nulls ?", Options = new[] { "LEFT JOIN", "INNER JOIN", "RIGHT JOIN", "CROSS JOIN" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction d'agrégation compte le nombre d'enregistrements ?", Options = new[] { "COUNT()", "SUM()", "AVG()", "TOTAL()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction supprime toutes les lignes d'une table sans journalisation ligne par ligne ?", Options = new[] { "TRUNCATE TABLE", "DELETE FROM", "DROP TABLE", "REMOVE TABLE" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction DDL modifie la structure d'une table existante ?", Options = new[] { "ALTER TABLE", "UPDATE TABLE", "MODIFY TABLE", "CHANGE TABLE" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé élimine les doublons des résultats d'un SELECT ?", Options = new[] { "DISTINCT", "UNIQUE", "DIFFERENT", "SINGLE" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel index garantit qu'aucune valeur en double n'est entrée dans une colonne ?", Options = new[] { "UNIQUE INDEX", "PRIMARY KEY", "FOREIGN KEY", "CHECK INDEX" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle contrainte empêche une colonne de contenir des valeurs nulles ?", Options = new[] { "NOT NULL", "UNIQUE", "CHECK", "DEFAULT" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle clé identifie de manière unique chaque enregistrement d'une table ?", Options = new[] { "PRIMARY KEY", "FOREIGN KEY", "UNIQUE INDEX", "CANDIDATE KEY" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle clé établit un lien d'intégrité référentielle entre deux tables ?", Options = new[] { "FOREIGN KEY", "PRIMARY KEY", "LINK KEY", "REFERENTIAL KEY" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction calcule la moyenne d'une colonne numérique ?", Options = new[] { "AVG()", "MEAN()", "AVERAGE()", "SUM()/COUNT()" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle clause SQL limite le nombre de lignes renvoyées ?", Options = new[] { "LIMIT", "TOP", "FETCH FIRST", "ROWNUM" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel opérateur recherche des correspondances de chaînes via des caractères génériques ?", Options = new[] { "LIKE", "MATCH", "IN", "BETWEEN" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel symbole sélectionne toutes les colonnes d'une table ?", Options = new[] { "*", "all", "%", "." }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mot-clé combine les résultats de deux SELECT en éliminant les doublons ?", Options = new[] { "UNION", "JOIN", "COMBINE", "MERGE" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle fonction d'agrégation retourne la valeur la plus élevée d'une colonne ?", Options = new[] { "MAX()", "MIN()", "HIGH()", "GREATEST()" }, CorrectIndex = 0 }
                    }
                },
                {
                    "Docker", new List<QuestionTemplate>
                    {
                        new QuestionTemplate { Text = "Comment s'appelle le fichier texte contenant les instructions pour assembler une image Docker ?", Options = new[] { "Dockerfile", "docker-compose.yml", "docker.config", "Manifest" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction de Dockerfile définit l'image parente de départ ?", Options = new[] { "FROM", "START WITH", "BASE", "IMAGE" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction de Dockerfile exécute une commande pendant la phase de build ?", Options = new[] { "RUN", "CMD", "ENTRYPOINT", "EXEC" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction définit la commande par défaut lancée au démarrage du conteneur ?", Options = new[] { "CMD", "RUN", "BUILD", "ENV" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande construit une image à partir d'un Dockerfile ?", Options = new[] { "docker build", "docker run", "docker create", "docker compile" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande liste les conteneurs Docker en cours d'exécution ?", Options = new[] { "docker ps", "docker list", "docker run -l", "docker images" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande lance l'exécution d'un conteneur à partir d'une image ?", Options = new[] { "docker run", "docker start", "docker play", "docker exec" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel drapeau (-flag) démarre un conteneur en arrière-plan (mode détaché) ?", Options = new[] { "-d", "-b", "-p", "-i" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel drapeau fait correspondre un port de la machine hôte à un port du conteneur ?", Options = new[] { "-p", "-p:port", "-port", "-m" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel mécanisme Docker offre un stockage persistant partagé indépendant du cycle de vie du conteneur ?", Options = new[] { "Volume", "Bind Mount", "Network", "Registry" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande arrête proprement un conteneur actif ?", Options = new[] { "docker stop", "docker kill", "docker pause", "docker end" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande supprime une image locale ?", Options = new[] { "docker rmi", "docker rm", "docker image delete", "docker purge" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande supprime tous les conteneurs, réseaux et images non utilisés ?", Options = new[] { "docker system prune", "docker clean", "docker purge", "docker system reset" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel outil permet de configurer et lancer des applications multiconteneurs via un fichier YAML ?", Options = new[] { "Docker Compose", "Docker Swarm", "Kubernetes", "Docker Registry" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction Dockerfile copie des fichiers du répertoire hôte local dans l'image ?", Options = new[] { "COPY", "ADD", "MOVE", "PUT" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande CLI affiche les logs d'un conteneur spécifique ?", Options = new[] { "docker logs", "docker show-logs", "docker cat", "docker inspect" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle commande lance un nouveau processus interactif (comme bash) dans un conteneur en cours d'exécution ?", Options = new[] { "docker exec -it", "docker run -it", "docker attach", "docker ssh" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quel registre officiel stocke et distribue les images Docker ?", Options = new[] { "Docker Hub", "GitHub", "NPM Registry", "Docker Registry Server" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction de Dockerfile définit le dossier de travail par défaut pour les instructions suivantes ?", Options = new[] { "WORKDIR", "CD", "DIR", "FOLDER" }, CorrectIndex = 0 },
                        new QuestionTemplate { Text = "Quelle instruction documente le port réseau sur lequel le conteneur écoutera au runtime ?", Options = new[] { "EXPOSE", "PORT", "NETWORK", "LISTEN" }, CorrectIndex = 0 }
                    }
                }
            };

            foreach (var category in templates.Keys)
            {
                var qList = templates[category];

                // 1. Générer le Quiz Facile (5 Qs, index 0 à 4)
                var easyQuiz = new Quiz
                {
                    Title = $"{category} - Niveau Facile",
                    Description = $"Évaluez vos bases en {category} avec ce quiz.",
                    Category = category,
                    Level = "Facile",
                    QuestionCount = 5,
                    IsExam = false
                };
                AddQuestionsToQuiz(easyQuiz, qList.Take(5));
                context.Quizzes.Add(easyQuiz);

                // 2. Générer le Quiz Moyen (10 Qs, index 0 à 9)
                var mediumQuiz = new Quiz
                {
                    Title = $"{category} - Niveau Moyen",
                    Description = $"Allez plus loin dans vos compétences de {category}.",
                    Category = category,
                    Level = "Moyen",
                    QuestionCount = 10,
                    IsExam = false
                };
                AddQuestionsToQuiz(mediumQuiz, qList.Take(10));
                context.Quizzes.Add(mediumQuiz);

                // 3. Générer le Quiz Difficile (15 Qs, index 0 à 14)
                var hardQuiz = new Quiz
                {
                    Title = $"{category} - Niveau Difficile",
                    Description = $"Testez votre expertise et résolvez des concepts avancés en {category}.",
                    Category = category,
                    Level = "Difficile",
                    QuestionCount = 15,
                    IsExam = false
                };
                AddQuestionsToQuiz(hardQuiz, qList.Take(15));
                context.Quizzes.Add(hardQuiz);

                // 4. Générer l'Examen Officiel (10 Qs, index 5 à 14)
                var examQuiz = new Quiz
                {
                    Title = $"Examen Officiel : Certification {category}",
                    Description = $"Examen officiel de certification en {category}. Obtenez une note sur 20 pour obtenir votre bulletin.",
                    Category = category,
                    Level = "Difficile", // L'examen est global et exigeant
                    QuestionCount = 10,
                    IsExam = true // Indique que c'est un examen officiel !
                };
                AddQuestionsToQuiz(examQuiz, qList.Skip(5).Take(10));
                context.Quizzes.Add(examQuiz);
            }

            context.SaveChanges();
        }

        private static void AddQuestionsToQuiz(Quiz quiz, IEnumerable<QuestionTemplate> templates)
        {
            foreach (var t in templates)
            {
                var question = new Question
                {
                    Text = t.Text,
                    Quiz = quiz
                };

                for (int idx = 0; idx < t.Options.Length; idx++)
                {
                    var opt = new Option
                    {
                        Text = t.Options[idx],
                        IsCorrect = idx == t.CorrectIndex,
                        Question = question
                    };
                    question.Options.Add(opt);
                }

                quiz.Questions.Add(question);
            }
        }
    }
}
