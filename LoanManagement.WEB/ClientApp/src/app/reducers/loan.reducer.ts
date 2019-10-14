import * as loanActions from './../actions/loan.action';

export function loanReducer(state = [], action: loanActions.Action) {
    switch (action.type) {
        case loanActions.GET_LOANS_SUCCESS: { return action.payload }
        default: { return state}
    }

}

