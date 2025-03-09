//(*NEWBYME*) New file to handle search functionality */
namespace music_manager_starter.Client.Services;

/*(*NEWBYME*) acts as a bridge between MainLayout.razor's search bar
and the corresponding songs that are to be displayed in Index.razor*/
public class SearchService{
    private string _searchTerm = "";
    public string SearchTerm{
        get{
            return _searchTerm;
        }
        set{
            //value is the string assigned to SearchTerm (what gets typed in the search bar)
            _searchTerm = value;
            /*triggers OnSearchChanged event if OnSearchChanged is NOT null; it has subscribers (for instance,
            a 'subscriber' was added via the line "SearchService.OnSearchChanged += FilterSongs;" 
            in OnInitializedAsync() Task in Index.razor)
            (? = shorthand null check)*/  
            OnSearchChanged?.Invoke();
        }
    }
    /*declaring OnSearchChanged event DELEGATE (for SearchService.cs to communicate to Index.razor that 
    the search bar was changed)
    Action event; no data(no params or return value), just informing that a change has taken place. 
    Holds a list of methods/functions to call when invoked. FilterSong() function gets subscribed to 
    this event with the line "SearchService.OnSearchChanged += FilterSongs;" in OnInitializedAsync() 
    Task in Index.razor */
    public event Action OnSearchChanged;
}