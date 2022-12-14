using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Project_To_Turn_In
{
    /// <summary>
    /// The class representing a controller for the minikindle book library
    /// </summary>
    public class BookController
    {
        /// <summary>
        /// the location of the book text file
        /// </summary>
        private static readonly string bookfileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "library.txt");

        /// <summary>
        /// the list of books
        /// </summary>
        private List<Book> BooksList = new List<Book>();

        /// <summary>
        /// Enumerate through the list of books
        /// </summary>
        public IEnumerable<Book> Books => BooksList;

        /// <summary>
        /// The count of books
        /// </summary>
        public int BookCount => BooksList.Count;

        /// <summary>
        /// Default constructor - might need to change the later
        /// </summary>
        public BookController()
        {
            Sync(SyncStrategy.Fetch);
        }

        /// <summary>
        /// Add list of Books
        /// </summary>
        /// <param name="booksList">the list of books</param>
        public BookController(List<Book> booksList)
        {
            BooksList = booksList;
        }

        /// <summary>
        /// Constructor with action delegates this one is probably what you want to hook into for the front end
        /// </summary>
        /// <param name="addB">the add book</param>
        /// <param name="removeB">the remove book</param>
        /// <param name="updateB">the update book</param>
        /// <param name="setPage">set the current page that the user is viewing</param>
        /// <param name="getBooks">get the list of books</param>
        [Obsolete("Not in use for the current project")]
        public BookController(Action<Book> addB, Action<Book> removeB, Action<Book> updateB, Action<Book, Page> setPage, Func<Book[]> getBooks)
        {
            addB = AddBook;
            removeB = RemoveBook;
            updateB = UpdateBook;
            getBooks = GetBooks;
            setPage = SetCurrentPage;

            Sync(SyncStrategy.Fetch);
        }

        /// <summary>
        /// Add a book to the list
        /// </summary>
        /// <param name="b"></param>
        /// <exception cref="Exception">exception</exception>
        public void AddBook(Book b)
        {

            if (BooksList.Count >= 5)
            {
                throw new Exception("Cannot have more than 5 books");
            }

            BooksList.Add(b);

            Sync();
        }


        /// <summary>
        /// Remove a book from the list
        /// </summary>
        /// <param name="b">the book to remove from the list</param>
        public void RemoveBook(Book b)
        {
            BooksList.Remove(b);

            Sync();
        }

        /// <summary>
        /// Update a book in the list
        /// </summary>
        /// <param name="book">the new book</param>
        public void UpdateBook(Book book)
        {

            var oldB = BooksList.Find(x => x.ID == book.ID);

            if (oldB == null)
            {
                AddBook(book);
                return;
            }

            book.ID = oldB.ID;

            BooksList.Remove(oldB);
            BooksList.Add(book);

            Sync();
        }

        /// <summary>
        /// Get an array of books
        /// </summary>
        /// <returns>returns an array of book</returns>
        public Book[] GetBooks()
        {
            return Books.ToArray();
        }

        /// <summary>
        /// Set the current page (if you are looking to go to the next page or back a page, just find the page and send it here)
        /// </summary>
        /// <param name="b">the book</param>
        /// <param name="p">the page</param>
        public void SetCurrentPage(Book b, Page p) //read comments above
        {
            int currentP = p.PageNumber;
            b.CurrentPage = currentP;
            UpdateBook(b);
        }

        #region no need to look at this lol

        /// <summary>
        /// Sync to the server (text file)
        /// </summary>
        /// <param name="strat">the sync strategy</param>
        private void Sync(SyncStrategy strat = SyncStrategy.Save)
        {
            if (strat == SyncStrategy.Fetch)
            {

                List<Book> books = Deserialize();

                if (books != BooksList)
                    BooksList = books;
            }
            else if (strat == SyncStrategy.Save)
            {
                Serialize();
            }
        }

        /// <summary>
        /// Update the books list
        /// </summary>
        private void Serialize()
        {

            var json = JsonSerializer.Serialize<List<Book>>(BooksList);

            using (FileStream stream = File.OpenWrite(bookfileLocation))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(json);
                }
            }
        }

        /// <summary>
        /// Get the books list
        /// </summary>
        /// <returns></returns>
        private List<Book> Deserialize()
        {
            //try
            //{

            if (File.Exists(bookfileLocation))
            {

                using (FileStream stream = File.OpenRead(bookfileLocation))
                {
                    try
                    {
                        var json = JsonSerializer.Deserialize<List<Book>>(stream);

                        if (json != null)
                            return json;
                        else
                            return new List<Book>();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error opening the book files");
                        return new List<Book>();    
                    }
                }
            }
            else
            {
                return new List<Book>();
            }

            //}
            //catch (IOException ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //    return new List<Book>();
            //}
        }
        #endregion


        public Book GenerateMockupBooks()
        {
            string str =
                "A SQUAT grey building of only thirty-four stories. Over the main en- " +
 "trance the words, CENTRAL LONDON HATCHERY AND CONDITIONING " +
 "CENTRE, and, in a shield, the World State's motto, COMMUNITY, IDEN- " +
 "TITY, STABILITY. " +
 "" +
 "The enormous room on the ground floor faced towards the north. Cold " +
 "for all the summer beyond the panes, for all the tropical heat of the " +
 "room itself, a harsh thin light glared through the windows, hungrily " +
 "seeking some draped lay figure, some pallid shape of academic goose- " +
 "flesh, but finding only the glass and nickel and bleakly shining porce- " +
 "lain of a laboratory. Wintriness responded to wintriness. The overalls of " +
 "the workers were white, their hands gloved with a pale corpse- " +
 "coloured rubber. The light was frozen, dead, a ghost. Only from the " +
 "yellow barrels of the microscopes did it borrow a certain rich and living " +
 "substance, lying along the polished tubes like butter, streak after " +
 "luscious streak in long recession down the work tables. " +
 "" +
 "\"And this,\" said the Director opening the door, \"is the Fertilizing " +
 "Room.\" " +
 "" +
 "Bent over their instruments, three hundred Fertilizers were plunged, as " +
 "the Director of Hatcheries and Conditioning entered the room, in the " +
 "" +
 "" +
 "" +
 "scarcely breathing silence, the absent-minded, soliloquizing hum or " +
 "whistle, of absorbed concentration. A troop of newly arrived students, " +
 "very young, pink and callow, followed nervously, rather abjectly, at the " +
 "Director's heels. Each of them carried a notebook, in which, whenever " +
 "the great man spoke, he desperately scribbled. Straight from the " +
 "horse's mouth. It was a rare privilege. The D. H. C. for Central London " +
 "always made a point of personally conducting his new students round " +
 "the various departments. " +
 "" +
 "\"Just to give you a general idea,\" he would explain to them. For of " +
 "course some sort of general idea they must have, if they were to do " +
 "their work intelligently-though as little of one, if they were to be good " +
 "and happy members of society, as possible. For particulars, as every " +
 "one knows, make for virtue and happiness; generalities are intellectu- " +
 "ally necessary evils. Not philosophers but fret-sawyers and stamp col- " +
 "lectors compose the backbone of society. " +
 "" +
 "\"To-morrow,\" he would add, smiling at them with a slightly menacing " +
 "geniality, \"you'll be settling down to serious work. You won't have time " +
 "for generalities. Meanwhile ...\" " +
 "" +
 "Meanwhile, it was a privilege. Straight from the horse's mouth into the " +
 "notebook. The boys scribbled like mad. " +
 "" +
 "Tall and rather thin but upright, the Director advanced into the room. " +
 "He had a long chin and big rather prominent teeth, just covered, when " +
 "he was not talking, by his full, floridly curved lips. Old, young? Thirty? " +
 "Fifty? Fifty-five? It was hard to say. And anyhow the question didn't " +
 "arise; in this year of stability, A. F. 632, it didn't occur to you to ask it. " +
 "" +
 "\"I shall begin at the beginning,\" said the D.H.C. and the more zealous " +
 "students recorded his intention in their notebooks: Begin at the begin- " +
 "ning. \"These,\" he waved his hand, \"are the incubators.\" And opening " +
 "an insulated door he showed them racks upon racks of numbered test- " +
 "tubes. \"The week's supply of ova. Kept,\" he explained, \"at blood heat; " +
 "whereas the male gametes,\" and here he opened another door, \"they " +
 "have to be kept at thirty-five instead of thirty-seven. Full blood heat " +
 "sterilizes.\" Rams wrapped in theremogene beget no lambs. " +
 "" +
 "Still leaning against the incubators he gave them, while the pencils " +
 "scurried illegibly across the pages, a brief description of the modern " +
 "" +
 "" +
 "" +
 "fertilizing process; spoke first, of course, of its surgical introduc- " +
 "tion-\"the operation undergone voluntarily for the good of Society, not " +
 "to mention the fact that it carries a bonus amounting to six months' " +
 "salary\"; continued with some account of the technique for preserving " +
 "the excised ovary alive and actively developing; passed on to a consid- " +
 "eration of optimum temperature, salinity, viscosity; referred to the liq- " +
 "uor in which the detached and ripened eggs were kept; and, leading " +
 "his charges to the work tables, actually showed them how this liquor " +
 "was drawn off from the test-tubes; how it was let out drop by drop " +
 "onto the specially warmed slides of the microscopes; how the eggs " +
 "which it contained were inspected for abnormalities, counted and " +
 "transferred to a porous receptacle; how (and he now took them to " +
 "watch the operation) this receptacle was immersed in a warm bouillon " +
 "containing free-swimming spermatozoa-at a minimum concentration " +
 "of one hundred thousand per cubic centimetre, he insisted; and how, " +
 "after ten minutes, the container was lifted out of the liquor and its " +
 "contents re-examined; how, if any of the eggs remained unfertilized, it " +
 "was again immersed, and, if necessary, yet again; how the fertilized " +
 "ova went back to the incubators; where the Alphas and Betas re- " +
 "mained until definitely bottled; while the Gammas, Deltas and Epsilons " +
 "were brought out again, after only thirty-six hours, to undergo Bo- " +
 "kanovsky's Process. " +
 "" +
 "\"Bokanovsky's Process,\" repeated the Director, and the students un- " +
 "derlined the words in their little notebooks. " +
 "" +
 "One egg, one embryo, one adult-normality. But a bokanovskified egg " +
 "will bud, will proliferate, will divide. From eight to ninety-six buds, and " +
 "every bud will grow into a perfectly formed embryo, and every embryo " +
 "into a full-sized adult. Making ninety-six human beings grow where " +
 "only one grew before. Progress. " +
 "" +
 "\"Essentially,\" the D.H.C. concluded, \"bokanovskification consists of a " +
 "series of arrests of development. We check the normal growth and, " +
 "paradoxically enough, the egg responds by budding.\" " +
 "" +
 "Responds by budding. The pencils were busy. " +
 "" +
 "He pointed. On a very slowly moving band a rack-full of test-tubes was " +
 "entering a large metal box, another, rack-full was emerging. Machinery " +
 "faintly purred. It took eight minutes for the tubes to go through, he " +
 "" +
 "" +
 "" +
 "told them. Eight minutes of hard X-rays being about as much as an " +
 "egg can stand. A few died; of the rest, the least susceptible divided " +
 "into two; most put out four buds; some eight; all were returned to the " +
 "incubators, where the buds began to develop; then, after two days, " +
 "were suddenly chilled, chilled and checked. Two, four, eight, the buds " +
 "in their turn budded; and having budded were dosed almost to death " +
 "with alcohol; consequently burgeoned again and having budded-bud " +
 "out of bud out of bud-were thereafter-further arrest being generally " +
 "fatal-left to develop in peace. By which time the original egg was in a " +
 "fair way to becoming anything from eight to ninety-six embryos- a " +
 "prodigious improvement, you will agree, on nature. Identical twins-but " +
 "not in piddling twos and threes as in the old viviparous days, when an " +
 "egg would sometimes accidentally divide; actually by dozens, by " +
 "scores at a time. " +
 "" +
 "\"Scores,\" the Director repeated and flung out his arms, as though he " +
 "were distributing largesse. \"Scores.\" " +
 "" +
 "But one of the students was fool enough to ask where the advantage " +
 "lay. " +
 "" +
 "\"My good boy!\" The Director wheeled sharply round on him. \"Can't you " +
 "see? Can't you see?\" He raised a hand; his expression was solemn. " +
 "\"Bokanovsky's Process is one of the major instruments of social stabil- " +
 "ity!\" " +
 "" +
 "Major instruments of social stability. " +
 "" +
 "Standard men and women; in uniform batches. The whole of a small " +
 "factory staffed with the products of a single bokanovskified egg. " +
 "" +
 "\"Ninety-six identical twins working ninety-six identical machines!\" The " +
 "voice was almost tremulous with enthusiasm. \"You really know where " +
 "you are. For the first time in history.\" He quoted the planetary motto. " +
 "\"Community, Identity, Stability.\" Grand words. \"If we could bo- " +
 "kanovskify indefinitely the whole problem would be solved.\" " +
 "" +
 "Solved by standard Gammas, unvarying Deltas, uniform Epsilons. Mil- " +
 "lions of identical twins. The principle of mass production at last applied " +
 "to biology. " +
 "" +
 "" +
 "" +
 "\"But, alas,\" the Director shook his head, \"we can't bokanovskify indefi- " +
 "nitely.\" " +
 "" +
 "Ninety-six seemed to be the limit; seventy-two a good average. From " +
 "the same ovary and with gametes of the same male to manufacture as " +
 "many batches of identical twins as possible-that was the best (sadly a " +
 "second best) that they could do. And even that was difficult. " +
 "" +
 "\"For in nature it takes thirty years for two hundred eggs to reach ma- " +
 "turity. But our business is to stabilize the population at this moment, " +
 "here and now. Dribbling out twins over a quarter of a century-what " +
 "would be the use of that?\" " +
 "" +
 "Obviously, no use at all. But Podsnap's Technique had immensely ac- " +
 "celerated the process of ripening. They could make sure of at least a " +
 "hundred and fifty mature eggs within two years. Fertilize and bo- " +
 "kanovskify-in other words, multiply by seventy-two-and you get an " +
 "average of nearly eleven thousand brothers and sisters in a hundred " +
 "and fifty batches of identical twins, all within two years of the same " +
 "age. " +
 "" +
 "\"And in exceptional cases we can make one ovary yield us over fifteen " +
 "thousand adult individuals.\" " +
 "" +
 "Beckoning to a fair-haired, ruddy young man who happened to be " +
 "passing at the moment. \"Mr. Foster,\" he called. The ruddy young man " +
 "approached. \"Can you tell us the record for a single ovary, Mr. Foster?\" " +
 "" +
 "\"Sixteen thousand and twelve in this Centre,\" Mr. Foster replied with- " +
 "out hesitation. He spoke very quickly, had a vivacious blue eye, and " +
 "took an evident pleasure in quoting figures. \"Sixteen thousand and " +
 "twelve; in one hundred and eighty-nine batches of identicals. But of " +
 "course they've done much better,\" he rattled on, \"in some of the tropi- " +
 "cal Centres. Singapore has often produced over sixteen thousand five " +
 "hundred; and Mombasa has actually touched the seventeen thousand " +
 "mark. But then they have unfair advantages. You should see the way a " +
 "negro ovary responds to pituitary! It's quite astonishing, when you're " +
 "used to working with European material. Still,\" he added, with a laugh " +
 "(but the light of combat was in his eyes and the lift of his chin was " +
 "challenging), \"still, we mean to beat them if we can. I'm working on a " +
 "wonderful Delta-Minus ovary at this moment. Only just eighteen " +
 "" +
 "" +
 "" +
 "months old. Over twelve thousand seven hundred children already, ei- " +
 "ther decanted or in embryo. And still going strong. We'll beat them " +
 "yet.\" " +
 "" +
 "\"That's the spirit I like!\" cried the Director, and clapped Mr. Foster on " +
 "the shoulder. \"Come along with us, and give these boys the benefit of " +
 "your expert knowledge.\" " +
 "" +
 "Mr. Foster smiled modestly. \"With pleasure.\" They went. " +
 "In the Bottling Room all was harmonious bustle and ordered activity. " +
 "Flaps of fresh sow's peritoneum ready cut to the proper size came " +
 "shooting up in little lifts from the Organ Store in the sub-basement. " +
 "Whizz and then, click! the lift-hatches hew open; the bottle-liner had " +
 "only to reach out a hand, take the flap, insert, smooth-down, and be- " +
 "fore the lined bottle had had time to travel out of reach along the end- " +
 "less band, whizz, click! another flap of peritoneum had shot up from " +
 "the depths, ready to be slipped into yet another bottle, the next of that " +
 "slow interminable procession on the band. " +
 "" +
 "Next to the Liners stood the Matriculators. The procession advanced; " +
 "one by one the eggs were transferred from their test-tubes to the " +
 "larger containers; deftly the peritoneal lining was slit, the morula " +
 "dropped into place, the saline solution poured in ... and already the " +
 "bottle had passed, and it was the turn of the labellers. Heredity, date " +
 "of fertilization, membership of Bokanovsky Group-details were trans- " +
 "ferred from test-tube to bottle. No longer anonymous, but named, " +
 "identified, the procession marched slowly on; on through an opening in " +
 "the wall, slowly on into the Social Predestination Room. " +
 "\"Eighty-eight cubic metres of card-index,\" said Mr. Foster with relish, " +
 "as they entered. " +
 "" +
 "\"Containing all the relevant information,\" added the Director. " +
 "\"Brought up to date every morning.\" " +
 "\"And co-ordinated every afternoon.\" " +
 "\"On the basis of which they make their calculations.\" " +
 "\"So many individuals, of such and such quality,\" said Mr. Foster. " +
 "\"Distributed in such and such quantities.\" " +
 "\"The optimum Decanting Rate at any given moment.\" " +
 "\"Unforeseen wastages promptly made good.\" " +
 "" +
 "\"Promptly,\" repeated Mr. Foster. \"If you knew the amount of overtime I " +
 "had to put in after the last Japanese earthquake!\" He laughed good- " +
 "humouredly and shook his head. " +
 "" +
 "\"The Predestinators send in their figures to the Fertilizers.\" " +
 "\"Who give them the embryos they ask for.\" " +
 "" +
 "" +
 "" +
 "\"And the bottles come in here to be predestined in detail.\" " +
 "\"After which they are sent down to the Embryo Store.\" " +
 "\"Where we now proceed ourselves.\" " +
 "" +
 "And opening a door Mr. Foster led the way down a staircase into the " +
 "basement. " +
 "" +
 "The temperature was still tropical. They descended into a thickening " +
 "twilight. Two doors and a passage with a double turn insured the cellar " +
 "against any possible infiltration of the day. " +
 "" +
 "\"Embryos are like photograph film,\" said Mr. Foster waggishly, as he " +
 "pushed open the second door. \"They can only stand red light.\" " +
 "And in effect the sultry darkness into which the students now followed " +
 "him was visible and crimson, like the darkness of closed eyes on a " +
 "summer's afternoon. The bulging flanks of row on receding row and " +
 "tier above tier of bottles glinted with innumerable rubies, and among " +
 "the rubies moved the dim red spectres of men and women with purple " +
 "eyes and all the symptoms of lupus. The hum and rattle of machinery " +
 "faintly stirred the air. " +
 "" +
 "\"Give them a few figures, Mr. Foster,\" said the Director, who was tired " +
 "of talking. " +
 "" +
 "Mr. Foster was only too happy to give them a few figures. " +
 "Two hundred and twenty metres long, two hundred wide, ten high. He " +
 "pointed upwards. Like chickens drinking, the students lifted their eyes " +
 "towards the distant ceiling. " +
 "" +
 "Three tiers of racks: ground floor level, first gallery, second gallery. " +
 "The spidery steel-work of gallery above gallery faded away in all direc- " +
 "tions into the dark. Near them three red ghosts were busily unloading " +
 "demijohns from a moving staircase. " +
 "The escalator from the Social Predestination Room. " +
 "Each bottle could be placed on one of fifteen racks, each rack, though " +
 "you couldn't see it, was a conveyor traveling at the rate of thirty-three " +
 "and a third centimetres an hour. Two hundred and sixty-seven days at " +
 "eight metres a day. Two thousand one hundred and thirty-six metres in " +
 "all. One circuit of the cellar at ground level, one on the first gallery, " +
 "half on the second, and on the two hundred and sixty-seventh morn- " +
 "ing, daylight in the Decanting Room. Independent existence-so called. " +
 "\"But in the interval,\" Mr. Foster concluded, \"we've managed to do a lot " +
 "to them. Oh, a very great deal.\" His laugh was knowing and trium- " +
 "phant. " +
 "" +
 "\"That's the spirit I like,\" said the Director once more. \"Let's walk " +
 "around. You tell them everything, Mr. Foster.\" " +
 "" +
 "" +
 "" +
 "Mr. Foster duly told them. " +
 "" +
 "Told them of the growing embryo on its bed of peritoneum. Made them " +
 "taste the rich blood surrogate on which it fed. Explained why it had to " +
 "be stimulated with placentin and thyroxin. Told them of the corpus lu- " +
 "teum extract. Showed them the jets through which at every twelfth " +
 "metre from zero to 2040 it was automatically injected. Spoke of those " +
 "gradually increasing doses of pituitary administered during the final " +
 "ninety-six metres of their course. Described the artificial maternal cir- " +
 "culation installed in every bottle at Metre 112; showed them the reser- " +
 "voir of blood-surrogate, the centrifugal pump that kept the liquid mov- " +
 "ing over the placenta and drove it through the synthetic lung and " +
 "waste product filter. Referred to the embryo's troublesome tendency to " +
 "anaemia, to the massive doses of hog's stomach extract and foetal " +
 "foal's liver with which, in consequence, it had to be supplied. " +
 "Showed them the simple mechanism by means of which, during the " +
 "last two metres out of every eight, all the embryos were simultane- " +
 "ously shaken into familiarity with movement. Hinted at the gravity of " +
 "the so-called \"trauma of decanting,\" and enumerated the precautions " +
 "taken to minimize, by a suitable training of the bottled embryo, that " +
 "dangerous shock. Told them of the test for sex carried out in the " +
 "neighborhood of Metre 200. Explained the system of labelling-a T for " +
 "the males, a circle for the females and for those who were destined to " +
 "become freemartins a question mark, black on a white ground. " +
 "\"For of course,\" said Mr. Foster, \"in the vast majority of cases, fertility " +
 "is merely a nuisance. One fertile ovary in twelve hundred-that would " +
 "really be quite sufficient for our purposes. But we want to have a good " +
 "choice. And of course one must always have an enormous margin of " +
 "safety. So we allow as many as thirty per cent of the female embryos " +
 "to develop normally. The others get a dose of male sex-hormone every " +
 "twenty-four metres for the rest of the course. Result: they're decanted " +
 "as freemartins-structurally quite normal (except,\" he had to admit, " +
 "\"that they do have the slightest tendency to grow beards), but sterile. " +
 "Guaranteed sterile. Which brings us at last,\" continued Mr. Foster, \"out " +
 "of the realm of mere slavish imitation of nature into the much more in- " +
 "teresting world of human invention.\" " +
 "" +
 "He rubbed his hands. For of course, they didn't content themselves " +
 "with merely hatching out embryos: any cow could do that. " +
 "\"We also predestine and condition. We decant our babies as socialized " +
 "human beings, as Alphas or Epsilons, as future sewage workers or fu- " +
 "" +
 "" +
 "" +
 "ture ...\" He was going to say \"future World controllers,\" but correcting " +
 "himself, said \"future Directors of Hatcheries,\" instead. " +
 "The D.H.C. acknowledged the compliment with a smile. " +
 "They were passing Metre 320 on Rack 11. A young Beta-Minus me- " +
 "chanic was busy with screw-driver and spanner on the blood-surrogate " +
 "pump of a passing bottle. The hum of the electric motor deepened by " +
 "fractions of a tone as he turned the nuts. Down, down ... A final twist, " +
 "a glance at the revolution counter, and he was done. He moved two " +
 "paces down the line and began the same process on the next pump. " +
 "\"Reducing the number of revolutions per minute,\" Mr. Foster explained. " +
 "\"The surrogate goes round slower; therefore passes through the lung " +
 "at longer intervals; therefore gives the embryo less oxygen. Nothing " +
 "like oxygen-shortage for keeping an embryo below par.\" Again he " +
 "rubbed his hands. " +
 "" +
 "\"But why do you want to keep the embryo below par?\" asked an in- " +
 "genuous student. " +
 "" +
 "\"Ass!\" said the Director, breaking a long silence. \"Hasn't it occurred to " +
 "you that an Epsilon embryo must have an Epsilon environment as well " +
 "as an Epsilon heredity?\" " +
 "" +
 "It evidently hadn't occurred to him. He was covered with confusion. " +
 "\"The lower the caste,\" said Mr. Foster, \"the shorter the oxygen.\" The " +
 "first organ affected was the brain. After that the skeleton. At seventy " +
 "per cent of normal oxygen you got dwarfs. At less than seventy eye- " +
 "less monsters. " +
 "" +
 "\"Who are no use at all,\" concluded Mr. Foster. " +
 "" +
 "Whereas (his voice became confidential and eager), if they could dis- " +
 "cover a technique for shortening the period of maturation what a tri- " +
 "umph, what a benefaction to Society! " +
 "\"Consider the horse.\" " +
 "They considered it. " +
 "" +
 "Mature at six; the elephant at ten. While at thirteen a man is not yet " +
 "sexually mature; and is only full-grown at twenty. Hence, of course, " +
 "that fruit of delayed development, the human intelligence. " +
 "\"But in Epsilons,\" said Mr. Foster very justly, \"we don't need human in- " +
 "telligence.\" " +
 "" +
 "Didn't need and didn't get it. But though the Epsilon mind was mature " +
 "at ten, the Epsilon body was not fit to work till eighteen. Long years of " +
 "superfluous and wasted immaturity. If the physical development could " +
 "be speeded up till it was as quick, say, as a cow's, what an enormous " +
 "saving to the Community! " +
 "" +
 "" +
 "" +
 "\"Enormous!\" murmured the students. Mr. Foster's enthusiasm was in- " +
 "fectious. " +
 "" +
 "He became rather technical; spoke of the abnormal endocrine co- " +
 "ordination which made men grow so slowly; postulated a germinal mu- " +
 "tation to account for it. Could the effects of this germinal mutation be " +
 "undone? Could the individual Epsilon embryo be made a revert, by a " +
 "suitable technique, to the normality of dogs and cows? That was the " +
 "problem. And it was all but solved. " +
 "" +
 "Pilkington, at Mombasa, had produced individuals who were sexually " +
 "mature at four and full-grown at six and a half. A scientific triumph. " +
 "But socially useless. Six-year-old men and women were too stupid to " +
 "do even Epsilon work. And the process was an all-or-nothing one; ei- " +
 "ther you failed to modify at all, or else you modified the whole way. " +
 "They were still trying to find the ideal compromise between adults of " +
 "twenty and adults of six. So far without success. Mr. Foster sighed and " +
 "shook his head. " +
 "" +
 "Their wanderings through the crimson twilight had brought them to " +
 "the neighborhood of Metre 170 on Rack 9. From this point onwards " +
 "Rack 9 was enclosed and the bottle performed the remainder of their " +
 "journey in a kind of tunnel, interrupted here and there by openings " +
 "two or three metres wide. " +
 "\"Heat conditioning,\" said Mr. Foster. " +
 "" +
 "Hot tunnels alternated with cool tunnels. Coolness was wedded to dis- " +
 "comfort in the form of hard X-rays. By the time they were decanted " +
 "the embryos had a horror of cold. They were predestined to emigrate " +
 "to the tropics, to be miner and acetate silk spinners and steel workers. " +
 "Later on their minds would be made to endorse the judgment of their " +
 "bodies. \"We condition them to thrive on heat,\" concluded Mr. Foster. " +
 "\"Our colleagues upstairs will teach them to love it.\" " +
 "\"And that,\" put in the Director sententiously, \"that is the secret of hap- " +
 "piness and virtue-liking what you've got to do. All conditioning aims at " +
 "that: making people like their unescapable social destiny.\" " +
 "In a gap between two tunnels, a nurse was delicately probing with a " +
 "long fine syringe into the gelatinous contents of a passing bottle. The " +
 "students and their guides stood watching her for a few moments in si- " +
 "lence. " +
 "" +
 "\"Well, Lenina,\" said Mr. Foster, when at last she withdrew the syringe " +
 "and straightened herself up. " +
 "" +
 "The girl turned with a start. One could see that, for all the lupus and " +
 "the purple eyes, she was uncommonly pretty. " +
 "" +
 "" +
 "" +
 "\"Henry!\" Her smile flashed redly at him-a row of coral teeth. " +
 "\"Charming, charming,\" murmured the Director and, giving her two or " +
 "three little pats, received in exchange a rather deferential smile for " +
 "himself. " +
 "" +
 "\"What are you giving them?\" asked Mr. Foster, making his tone very " +
 "professional. " +
 "" +
 "\"Oh, the usual typhoid and sleeping sickness.\" " +
 "" +
 "\"Tropical workers start being inoculated at Metre 150,\" Mr. Foster ex- " +
 "plained to the students. \"The embryos still have gills. We immunize the " +
 "fish against the future man's diseases.\" Then, turning back to Lenina, " +
 "\"Ten to five on the roof this afternoon,\" he said, \"as usual.\" " +
 "\"Charming,\" said the Director once more, and, with a final pat, moved " +
 "away after the others. " +
 "" +
 "On Rack 10 rows of next generation's chemical workers were being " +
 "trained in the toleration of lead, caustic soda, tar, chlorine. The first of " +
 "a batch of two hundred and fifty embryonic rocket-plane engineers was " +
 "just passing the eleven hundred metre mark on Rack 3. A special " +
 "mechanism kept their containers in constant rotation. \"To improve " +
 "their sense of balance,\" Mr. Foster explained. \"Doing repairs on the " +
 "outside of a rocket in mid-air is a ticklish job. We slacken off the circu- " +
 "lation when they're right way up, so that they're half starved, and " +
 "double the flow of surrogate when they're upside down. They learn to " +
 "associate topsy-turvydom with well-being; in fact, they're only truly " +
 "happy when they're standing on their heads. " +
 "" +
 "\"And now,\" Mr. Foster went on, \"I'd like to show you some very inter- " +
 "esting conditioning for Alpha Plus Intellectuals. We have a big batch of " +
 "them on Rack 5. First Gallery level,\" he called to two boys who had " +
 "started to go down to the ground floor. " +
 "" +
 "\"They're round about Metre 900,\" he explained. \"You can't really do " +
 "any useful intellectual conditioning till the foetuses have lost their tails. " +
 "Follow me.\" " +
 "" +
 "But the Director had looked at his watch. \"Ten to three,\" he said. \"No " +
 "time for the intellectual embryos, I'm afraid. We must go up to the " +
 "Nurseries before the children have finished their afternoon sleep.\" " +
 "Mr. Foster was disappointed. \"At least one glance at the Decanting " +
 "Room,\" he pleaded. " +
 "\"Very well then.\" The Director smiled indulgently. \"Just one glance.\"";


            int chars = 1500;
            string nextLine = "";

            List<Page> pages = new List<Page>();

            for (int i = 0; i < str.Length; i++)
            {
                if (nextLine.Length < chars && i < str.Length - 1)
                    nextLine += str[i];
                else
                {
                    Page p = new Page()
                    {
                        Words = nextLine,
                        PageHeader = "Brave New World - Chapter 1",
                        PageNumber = pages.Count
                    };

                    pages.Add(p);
                    nextLine = "";
                }
            }

            Book b = new Book()
            {
                Title = "Brave New World",
                Pages = pages,
                CurrentPage = 0
            };

            return b;

        }
    }

    /// <summary>
    /// The sync strategy
    /// </summary>
    public enum SyncStrategy
    {
        Save,
        Fetch
    }
}
